#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using ClearCanvas.Common.Utilities;
using ClearCanvas.ImageViewer.Services.LocalDataStore;
using ClearCanvas.ImageViewer.Services.ServerTree;
using ClearCanvas.Dicom.ServiceModel.Query;

namespace ClearCanvas.ImageViewer.Configuration
{
	public static class DefaultServers
	{
		public static List<Server> SelectFrom(IEnumerable<Server> candidates)
		{
			StringCollection defaultServerPaths = DefaultServerSettings.Default.DefaultServerPaths;

			if (defaultServerPaths == null)
				return new List<Server>();

			return CollectionUtils.Select(candidates, delegate(Server node) { return defaultServerPaths.Contains(node.Path); });
		}

		public static List<Server> SelectFrom(Services.ServerTree.ServerTree serverTree)
		{
			List<Server> allServers = CollectionUtils.Map(serverTree.FindChildServers(),
				delegate(IServerTreeNode server) { return (Server) server; });
			
			return SelectFrom(allServers);
		}

		public static List<Server> GetAll()
		{
			ImageViewer.Services.ServerTree.ServerTree tree = new Services.ServerTree.ServerTree();
			return SelectFrom(tree);
		}

        public static IEnumerable<IStudyRootQuery> GetQueryInterfaces(bool includeLocal)
		{
            if (includeLocal)
            {
                IStudyRootQuery localDataStoreQuery;
                try
                {
                    localDataStoreQuery = (IStudyRootQuery) new LocalStudyRootQueryExtensionPoint().CreateExtension();
                }
                catch (NotSupportedException)
                {
                    localDataStoreQuery = null;
                }

                if (localDataStoreQuery != null)
                    yield return localDataStoreQuery;
            }

            string localAE = Services.ServerTree.ServerTree.GetClientAETitle();

			List<Server> defaultServers = DefaultServers.SelectFrom(new Services.ServerTree.ServerTree());
			List<Server> streamingServers = CollectionUtils.Select(defaultServers, 
				delegate(Server server) { return server.IsStreaming; });

			List<Server> nonStreamingServers = CollectionUtils.Select(defaultServers,
				delegate(Server server) { return !server.IsStreaming; });

			foreach (Server server in streamingServers)
			{
				DicomStudyRootQuery remoteQuery = new DicomStudyRootQuery(localAE, server.AETitle, server.Host, server.Port);
				yield return remoteQuery;
			}

			foreach (Server server in nonStreamingServers)
			{
				DicomStudyRootQuery remoteQuery = new DicomStudyRootQuery(localAE, server.AETitle, server.Host, server.Port);
				yield return remoteQuery;
			}
		}
	}
}
