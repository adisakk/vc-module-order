﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VirtoCommerce.OrderModule.Web.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class DigitalContentResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DigitalContentResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VirtoCommerce.OrderModule.Web.Resources.DigitalContentResource", typeof(DigitalContentResource).Assembly);
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
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///&lt;/head&gt;
        ///&lt;body style=&quot;font-family: Arial, Helvetica, sans-serif;&quot;&gt;
        ///    &lt;div style=&quot;border: 1px solid #E0DCDA;&quot;&gt;
        ///
        ///
        ///&lt;div style=&quot;background-color: #F9F9F9; font-size: 12px; margin: 2px; padding: 10px;&quot;&gt;
        ///            &lt;div&gt;
        ///                &lt;span style=&quot;width: 400px;&quot;&gt;&lt;img src=&quot;http://www.ratanachon.com/wp-content/uploads/2017/02/DigitalContent.jpg&quot; width=&quot;140&quot; /&gt;&lt;/span&gt;
        ///            &lt;/div&gt;
        ///
        ///        &lt;div style=&quot;background-color: #E0DCDA; margin: 2px; padding: 10px;&quot;&gt;
        ///            &lt;span styl [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Body {
            get {
                return ResourceManager.GetString("Body", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Digital contents for order - &lt;strong&gt;{{ customer_order.number }}&lt;/strong&gt;.
        /// </summary>
        internal static string Subject {
            get {
                return ResourceManager.GetString("Subject", resourceCulture);
            }
        }
    }
}
