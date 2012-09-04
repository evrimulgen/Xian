﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.ImageViewer.Web {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SR {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SR() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ClearCanvas.ImageViewer.Web.SR", typeof(SR).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Studies matching the specified accession number could not be found..
        /// </summary>
        internal static string MessageAccessionStudiesNotFound {
            get {
                return ResourceManager.GetString("MessageAccessionStudiesNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unexpected error has occurred while searching for priors. Please contact your PACS administrator..
        /// </summary>
        internal static string MessageLoadPriorsFindErrors {
            get {
                return ResourceManager.GetString("MessageLoadPriorsFindErrors", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No studies could be found for the specified patient..
        /// </summary>
        internal static string MessagePatientStudiesNotFound {
            get {
                return ResourceManager.GetString("MessagePatientStudiesNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The search for prior studies did not complete successfully because at least one of your priors servers was unreachable.
        ///Although some priors may be available, please be aware that you may be working with an incomplete patient history..
        /// </summary>
        internal static string MessagePriorsIncomplete {
            get {
                return ResourceManager.GetString("MessagePriorsIncomplete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The study could not be loaded..
        /// </summary>
        internal static string MessageStudyCouldNotBeLoaded {
            get {
                return ResourceManager.GetString("MessageStudyCouldNotBeLoaded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Layout Manager.
        /// </summary>
        internal static string TooltipLayoutManager {
            get {
                return ResourceManager.GetString("TooltipLayoutManager", resourceCulture);
            }
        }
    }
}
