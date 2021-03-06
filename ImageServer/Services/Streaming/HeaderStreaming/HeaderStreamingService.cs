#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.IO;
using System.ServiceModel;
using ClearCanvas.Common;
using ClearCanvas.Common.Statistics;
using ClearCanvas.Dicom.ServiceModel.Streaming;
using ClearCanvas.ImageServer.Common.Exceptions;
using ClearCanvas.ImageServer.Services.Streaming.ImageStreaming.Handlers;

namespace ClearCanvas.ImageServer.Services.Streaming.HeaderStreaming
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode=InstanceContextMode.PerSession)]
    public class HeaderStreamingService : IHeaderStreamingService
    {
        #region Private Members
        private string _callerID;
        private Guid _id = Guid.NewGuid();
        #endregion

        #region Protected Properties

        /// <summary>
        /// Gets the unique ID of the service instance
        /// </summary>
        public string ID
        {
            get { return _id.ToString(); }
        }

        public string CallerID
        {
            get { return _callerID; }
            set { _callerID = value; }
        }

        #endregion

        #region IHeaderStreamingService Members

        public Stream GetStudyHeader(string callingAETitle, HeaderStreamingParameters parameters)
        {
            ConnectionMonitor.GetMonitor(OperationContext.Current.Host).AddContext(OperationContext.Current);
                
            HeaderStreamingStatistics stats = new HeaderStreamingStatistics();
            stats.ProcessTime.Start();

            HeaderLoader loader = null;

            try
            {
                Platform.CheckForEmptyString(callingAETitle, "callingAETitle");
                Platform.CheckForNullReference(parameters, "parameters");
                Platform.CheckForEmptyString(parameters.ReferenceID, "parameters.ReferenceID");
                Platform.CheckForEmptyString(parameters.ServerAETitle, "parameters.ServerAETitle");
                Platform.CheckForEmptyString(parameters.StudyInstanceUID, "parameters.StudyInstanceUID");

                Platform.Log(LogLevel.Debug, "Received request from {0}. Ref # {1} ", callingAETitle, parameters.ReferenceID);

                HeaderStreamingContext context = new HeaderStreamingContext();
                context.ServiceInstanceID = ID;
                context.CallerAE = callingAETitle;
                context.Parameters = parameters;

                // TODO: perform permission check on callingAETitle

                loader = new HeaderLoader(context);
                Stream stream = loader.Load();
                if (stream == null)
                    throw new FaultException(loader.FaultDescription);

                Platform.Log(LogLevel.Debug, "Response sent to {0}. Ref # {1} ", callingAETitle, parameters.ReferenceID);

                return stream;
            }
            catch (ArgumentException e)
            {
                throw new FaultException(e.Message);
            }
            catch (StudyNotFoundException)
            {
                throw new FaultException<StudyNotFoundFault>(
                            new StudyNotFoundFault(), String.Format(SR.FaultNotExists, parameters.StudyInstanceUID, parameters.ServerAETitle));
            }
            catch (StudyIsNearlineException e)
            {
				throw new FaultException<StudyIsNearlineFault>(
							new StudyIsNearlineFault() { IsStudyBeingRestored = e.RestoreRequested },
							String.Format(SR.FaultStudyIsNearline, parameters.StudyInstanceUID));
            }
            catch (StudyAccessException e)
            {
                if (e.InnerException != null)
                {
                    if (e.InnerException is FileNotFoundException)
                    {
                        throw new FaultException<StudyIsInUseFault>(
                            new StudyIsInUseFault(e.StudyState.Description),
                            String.Format(SR.FaultFaultStudyTemporarilyNotAccessible, parameters.StudyInstanceUID, e.StudyState));

                    }
                }
                throw new FaultException<StudyIsInUseFault>(
                                new StudyIsInUseFault(e.StudyState.Description),
                                String.Format(SR.FaultFaultStudyTemporarilyNotAccessible, parameters.StudyInstanceUID, e.StudyState));
            }
			catch (FilesystemNotReadableException e)
			{
				//interpret as generic fault
				throw new FaultException(e.Message);
			}
			catch (FileNotFoundException e)
            {
                // OOPS.. the header is missing
                Platform.Log(LogLevel.Error, e, "Unable to process study header request from {0}", callingAETitle);
                throw new FaultException(SR.FaultHeaderIsNotAvailable);
            }
			catch (Exception e)
            {
                if (!(e is FaultException))
                    Platform.Log(LogLevel.Error, e, "Unable to process study header request from {0}", callingAETitle);

                throw new FaultException(e.Message);
            }
            finally
            {
                stats.ProcessTime.End();

                if (loader != null && Settings.Default.LogStatistics)
                {
                    stats.AddField("StudyInstanceUid", parameters.StudyInstanceUID);

                    stats.AddSubStats(loader.Statistics);
                    StatisticsLogger.Log(LogLevel.Info, stats);
                }
            }
        }

    	#endregion
    }
}