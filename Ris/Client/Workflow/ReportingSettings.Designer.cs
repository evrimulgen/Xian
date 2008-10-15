﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.832
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Ris.Client.Workflow {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
    internal sealed partial class ReportingSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static ReportingSettings defaultInstance = ((ReportingSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ReportingSettings())));
        
        public static ReportingSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AllowMultipleReportingWorkspaces {
            get {
                return ((bool)(this["AllowMultipleReportingWorkspaces"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool EnableTranscriptionWorkflow {
            get {
                return ((bool)(this["EnableTranscriptionWorkflow"]));
            }
        }
        
        /// <summary>
        /// A comma separated list of staff type codes used to determine which staff can be used as a Supervisor
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("A comma separated list of staff type codes used to determine which staff can be u" +
            "sed as a Supervisor")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("PRAD")]
        public string SupervisorStaffTypeFilters {
            get {
                return ((string)(this["SupervisorStaffTypeFilters"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SupervisorID {
            get {
                return ((string)(this["SupervisorID"]));
            }
            set {
                this["SupervisorID"] = value;
            }
        }
        
        /// <summary>
        /// A comma separated list of staff type codes used to determine which staff can be used as a downtime Transcriptionist
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("A comma separated list of staff type codes used to determine which staff can be u" +
            "sed as a downtime Transcriptionist")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("STRA")]
        public string DowntimeTranscriptionistStaffTypeFilters {
            get {
                return ((string)(this["DowntimeTranscriptionistStaffTypeFilters"]));
            }
        }
    }
}
