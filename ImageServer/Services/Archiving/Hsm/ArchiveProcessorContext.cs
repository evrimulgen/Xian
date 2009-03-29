using System;
using System.IO;
using ClearCanvas.Common;
using ClearCanvas.ImageServer.Common.CommandProcessor;
using ClearCanvas.ImageServer.Model;

namespace ClearCanvas.ImageServer.Services.Archiving.Hsm
{
    /// <summary>
    /// Represents the execution context for an <see cref="ArchiveQueue"/>
    /// </summary>
    public class ArchiveProcessorContext : ExecutionContext
    {
        #region Private Fields
        private readonly Model.ArchiveQueue _item;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates an instance of <see cref="ArchiveProcessorContext"/>
        /// </summary>
        /// <param name="item"></param>
        public ArchiveProcessorContext(ArchiveQueue item)
        {
            Platform.CheckForNullReference(item, "item");
            _item = item;
            TempDirectory = InitTempDirectory();
        }
        #endregion

        #region Private Methods
        private string InitTempDirectory( )
        {
            StudyStorageLocation storage = StudyStorageLocation.FindStorageLocations(StudyStorage.Load(_item.StudyStorageKey))[0];
            if (storage == null)
                return base.TempDirectory;
            else
            {
                String basePath = Path.Combine(storage.FilesystemPath, "temp");
                basePath = Path.Combine(basePath, "Archive");
                String tempDirectory = Path.Combine(basePath, _item.GetKey().ToString());

                for (int i = 2; i < 1000; i++)
                {
                    if (!Directory.Exists(tempDirectory))
                    {
                        break;
                    }

                    tempDirectory = Path.Combine(basePath, String.Format("{0}({1})", _item.GetKey().ToString(), i));
                }

                if (!Directory.Exists(tempDirectory))
                    Directory.CreateDirectory(tempDirectory);
                return tempDirectory;
            }
        }
        #endregion
    }
}