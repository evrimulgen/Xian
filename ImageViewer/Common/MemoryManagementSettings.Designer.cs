﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.ImageViewer.Common {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class MemoryManagementSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static MemoryManagementSettings defaultInstance = ((MemoryManagementSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new MemoryManagementSettings())));
        
        public static MemoryManagementSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// The high watermark for process virtual memory.  When the high watermark is hit, memory management will unload objects until it reaches the low watermark.  A value of -1 means this value is computed automatically.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("The high watermark for process virtual memory.  When the high watermark is hit, m" +
            "emory management will unload objects until it reaches the low watermark.  A valu" +
            "e of -1 means this value is computed automatically.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-1")]
        public long HighWatermarkMegaBytes {
            get {
                return ((long)(this["HighWatermarkMegaBytes"]));
            }
        }
        
        /// <summary>
        /// The low watermark for process virtual memory.  When the high watermark is hit, memory management will unload objects until it reaches the low watermark.  A value of -1 means this value is computed automatically.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("The low watermark for process virtual memory.  When the high watermark is hit, me" +
            "mory management will unload objects until it reaches the low watermark.  A value" +
            " of -1 means this value is computed automatically.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-1")]
        public long LowWatermarkMegaBytes {
            get {
                return ((long)(this["LowWatermarkMegaBytes"]));
            }
        }
    }
}
