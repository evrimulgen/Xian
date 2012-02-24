#region License

// Copyright (c) 2012, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System.Configuration;

namespace ClearCanvas.Desktop
{
	[SettingsGroupDescription("Configures the installed localizations available for use in the application.")]
	[SettingsProvider(typeof (LocalFileSettingsProvider))]
	internal sealed partial class LocaleSettings
	{
		public LocaleSettings()
		{
			ApplicationSettingsRegistry.Instance.RegisterInstance(this);
		}
	}
}