﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.ImageViewer.Tools.Standard.ImageProperties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class ImagePropertiesSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static ImagePropertiesSettings defaultInstance = ((ImagePropertiesSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ImagePropertiesSettings())));
        
        public static ImagePropertiesSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Xml.XmlDocument StandardImagePropertiesXml {
            get {
                return ((global::System.Xml.XmlDocument)(this["StandardImagePropertiesXml"]));
            }
            set {
                this["StandardImagePropertiesXml"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ShowEmptyValues {
            get {
                return ((bool)(this["ShowEmptyValues"]));
            }
            set {
                this["ShowEmptyValues"] = value;
            }
        }
    }
}
