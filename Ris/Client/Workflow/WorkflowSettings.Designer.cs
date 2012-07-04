﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Ris.Client.Workflow {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class WorkflowSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static WorkflowSettings defaultInstance = ((WorkflowSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new WorkflowSettings())));
        
        public static WorkflowSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// Specifies whether the transcription portion of the workflow is enabled.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Specifies whether the transcription portion of the workflow is enabled.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool EnableTranscriptionWorkflow {
            get {
                return ((bool)(this["EnableTranscriptionWorkflow"]));
            }
        }
        
        /// <summary>
        /// Specifies whether the interpretation review (i.e. resident/supervisor) portion of the workflow is enabled.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Specifies whether the interpretation review (i.e. resident/supervisor) portion of" +
            " the workflow is enabled.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool EnableInterpretationReviewWorkflow {
            get {
                return ((bool)(this["EnableInterpretationReviewWorkflow"]));
            }
        }
        
        /// <summary>
        /// Specifies whether the transcription review (i.e. supervising transcriptionist) portion of the workflow is enabled.  This value is ignored if EnableTranscriptionWorkflow is false.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Specifies whether the transcription review (i.e. supervising transcriptionist) po" +
            "rtion of the workflow is enabled.  This value is ignored if EnableTranscriptionW" +
            "orkflow is false.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool EnableTranscriptionReviewWorkflow {
            get {
                return ((bool)(this["EnableTranscriptionReviewWorkflow"]));
            }
        }
    }
}
