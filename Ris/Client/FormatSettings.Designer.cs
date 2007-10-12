#region License

// Copyright (c) 2006-2007, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.832
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Ris.Client {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
    internal sealed partial class FormatSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static FormatSettings defaultInstance = ((FormatSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new FormatSettings())));
        
        public static FormatSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// Mask used on healthcard number input fields
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Mask used on healthcard number input fields")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0000 000 000")]
        public string HealthcardNumberMask {
            get {
                return ((string)(this["HealthcardNumberMask"]));
            }
        }
        
        /// <summary>
        /// Mask used on healthcard version code input field
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Mask used on healthcard version code input field")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LL")]
        public string HealthcardVersionCodeMask {
            get {
                return ((string)(this["HealthcardVersionCodeMask"]));
            }
        }
        
        /// <summary>
        /// Mask used on local telephone number input fields
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Mask used on local telephone number input fields")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("000-0000")]
        public string TelephoneNumberLocalMask {
            get {
                return ((string)(this["TelephoneNumberLocalMask"]));
            }
        }
        
        /// <summary>
        /// Mask used on full telephone number input fields
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Mask used on full telephone number input fields")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("(000) 000-0000")]
        public string TelephoneNumberFullMask {
            get {
                return ((string)(this["TelephoneNumberFullMask"]));
            }
        }
        
        /// <summary>
        /// Default display format for person names
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Default display format for person names")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%F, %G %M")]
        public string PersonNameDefaultFormat {
            get {
                return ((string)(this["PersonNameDefaultFormat"]));
            }
        }
        
        /// <summary>
        /// Default display format for healthcard numbers
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Default display format for healthcard numbers")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%A %N %V")]
        public string HealthcardDefaultFormat {
            get {
                return ((string)(this["HealthcardDefaultFormat"]));
            }
        }
        
        /// <summary>
        /// Default display format for addresses
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Default display format for addresses")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%S, %V %P %Z")]
        public string AddressDefaultFormat {
            get {
                return ((string)(this["AddressDefaultFormat"]));
            }
        }
        
        /// <summary>
        /// Country-code to suppress in display (all other country codes will be shown)
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Country-code to suppress in display (all other country codes will be shown)")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public string TelephoneNumberSuppressCountryCode {
            get {
                return ((string)(this["TelephoneNumberSuppressCountryCode"]));
            }
        }
        
        /// <summary>
        /// Default display format for telephone numbers
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Default display format for telephone numbers")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%c (%A) %N %X")]
        public string TelephoneNumberDefaultFormat {
            get {
                return ((string)(this["TelephoneNumberDefaultFormat"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%A %N")]
        public string MrnDefaultFormat {
            get {
                return ((string)(this["MrnDefaultFormat"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%A %N")]
        public string CompositeIdentifierDefaultFormat {
            get {
                return ((string)(this["CompositeIdentifierDefaultFormat"]));
            }
        }
    }
}
