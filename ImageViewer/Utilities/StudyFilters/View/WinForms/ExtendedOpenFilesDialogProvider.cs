#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System.Collections.Generic;
using System.Windows.Forms;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop;
using ClearCanvas.ImageViewer.Utilities.StudyFilters.Utilities;

namespace ClearCanvas.ImageViewer.Utilities.StudyFilters.View.WinForms
{
	[ExtensionOf(typeof (ExtendedOpenFilesDialog))]
	public class ExtendedOpenFilesDialogProvider : IExtendedOpenFilesDialogProvider
	{
		public IEnumerable<string> GetFiles(FileDialogCreationArgs args)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			PrepareFileDialog(dialog, args);
			dialog.CheckFileExists = true;
			dialog.ShowReadOnly = false;
			dialog.Multiselect = true;

			DialogResult dr = dialog.ShowDialog();
			if (dr == DialogResult.OK)
				return dialog.FileNames;

			return null;
		}

		private static void PrepareFileDialog(FileDialog dialog, FileDialogCreationArgs args)
		{
			dialog.AddExtension = !string.IsNullOrEmpty(args.FileExtension);
			dialog.DefaultExt = args.FileExtension;
			dialog.FileName = args.FileName;
			dialog.InitialDirectory = args.Directory;
			dialog.RestoreDirectory = true;
			dialog.Title = args.Title;

			dialog.Filter = StringUtilities.Combine(args.Filters, "|",
			                                        delegate(FileExtensionFilter f) { return f.Description + "|" + f.Filter; });
		}
	}
}