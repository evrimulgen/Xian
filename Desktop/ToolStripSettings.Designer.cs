﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Desktop {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    public sealed partial class ToolStripSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static ToolStripSettings defaultInstance = ((ToolStripSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ToolStripSettings())));
        
        public static ToolStripSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// Controls if tool strips longer than the window size should be wrapped.
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Controls if tool strips longer than the window size should be wrapped.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool WrapLongToolstrips {
            get {
                return ((bool)(this["WrapLongToolstrips"]));
            }
            set {
                this["WrapLongToolstrips"] = value;
            }
        }
        
        /// <summary>
        /// Controls the size of toolstrip buttons.
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Controls the size of toolstrip buttons.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Large")]
        public global::ClearCanvas.Desktop.IconSize IconSize {
            get {
                return ((global::ClearCanvas.Desktop.IconSize)(this["IconSize"]));
            }
            set {
                this["IconSize"] = value;
            }
        }
    }
}
