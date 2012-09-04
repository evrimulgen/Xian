﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Desktop.View.WinForms {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class DesktopViewSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static DesktopViewSettings defaultInstance = ((DesktopViewSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new DesktopViewSettings())));
        
        public static DesktopViewSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// Controls appearance of local toolbars
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Controls appearance of local toolbars")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Left")]
        public global::System.Windows.Forms.ToolStripItemAlignment LocalToolStripItemAlignment {
            get {
                return ((global::System.Windows.Forms.ToolStripItemAlignment)(this["LocalToolStripItemAlignment"]));
            }
        }
        
        /// <summary>
        /// Controls appearance of local toolbars
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Controls appearance of local toolbars")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ImageBeforeText")]
        public global::System.Windows.Forms.TextImageRelation LocalToolStripItemTextImageRelation {
            get {
                return ((global::System.Windows.Forms.TextImageRelation)(this["LocalToolStripItemTextImageRelation"]));
            }
        }
        
        /// <summary>
        /// Controls whether protected actions are visible in the desktop
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Controls whether protected actions are visible in the desktop")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ShowNonPermissibleActions {
            get {
                return ((bool)(this["ShowNonPermissibleActions"]));
            }
        }
        
        /// <summary>
        /// Controls whether protected actions are enabled in the desktop - this should neve be enabled in a production environment
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Controls whether protected actions are enabled in the desktop - this should neve " +
            "be enabled in a production environment")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool EnableNonPermissibleActions {
            get {
                return ((bool)(this["EnableNonPermissibleActions"]));
            }
        }
        
        /// <summary>
        /// XML document that stores information about window locations
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("XML document that stores information about window locations")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<desktops />")]
        public global::System.Xml.XmlDocument DesktopViewSettingsXml {
            get {
                return ((global::System.Xml.XmlDocument)(this["DesktopViewSettingsXml"]));
            }
            set {
                this["DesktopViewSettingsXml"] = value;
            }
        }
    }
}
