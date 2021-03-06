﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34003.
// 
#pragma warning disable 1591

namespace WebClient.PackageWS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="PackageWebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class PackageWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback addPackageOperationCompleted;
        
        private System.Threading.SendOrPostCallback getAllPackagesOperationCompleted;
        
        private System.Threading.SendOrPostCallback registerPackageOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public PackageWebService() {
            this.Url = global::WebClient.Properties.Settings.Default.WebClient_PackageWS_PackageWebService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event addPackageCompletedEventHandler addPackageCompleted;
        
        /// <remarks/>
        public event getAllPackagesCompletedEventHandler getAllPackagesCompleted;
        
        /// <remarks/>
        public event registerPackageCompletedEventHandler registerPackageCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/addPackage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void addPackage(package p) {
            this.Invoke("addPackage", new object[] {
                        p});
        }
        
        /// <remarks/>
        public void addPackageAsync(package p) {
            this.addPackageAsync(p, null);
        }
        
        /// <remarks/>
        public void addPackageAsync(package p, object userState) {
            if ((this.addPackageOperationCompleted == null)) {
                this.addPackageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnaddPackageOperationCompleted);
            }
            this.InvokeAsync("addPackage", new object[] {
                        p}, this.addPackageOperationCompleted, userState);
        }
        
        private void OnaddPackageOperationCompleted(object arg) {
            if ((this.addPackageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.addPackageCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getAllPackages", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public package[] getAllPackages() {
            object[] results = this.Invoke("getAllPackages", new object[0]);
            return ((package[])(results[0]));
        }
        
        /// <remarks/>
        public void getAllPackagesAsync() {
            this.getAllPackagesAsync(null);
        }
        
        /// <remarks/>
        public void getAllPackagesAsync(object userState) {
            if ((this.getAllPackagesOperationCompleted == null)) {
                this.getAllPackagesOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetAllPackagesOperationCompleted);
            }
            this.InvokeAsync("getAllPackages", new object[0], this.getAllPackagesOperationCompleted, userState);
        }
        
        private void OngetAllPackagesOperationCompleted(object arg) {
            if ((this.getAllPackagesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getAllPackagesCompleted(this, new getAllPackagesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/registerPackage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void registerPackage(int user_id, int package_id) {
            this.Invoke("registerPackage", new object[] {
                        user_id,
                        package_id});
        }
        
        /// <remarks/>
        public void registerPackageAsync(int user_id, int package_id) {
            this.registerPackageAsync(user_id, package_id, null);
        }
        
        /// <remarks/>
        public void registerPackageAsync(int user_id, int package_id, object userState) {
            if ((this.registerPackageOperationCompleted == null)) {
                this.registerPackageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnregisterPackageOperationCompleted);
            }
            this.InvokeAsync("registerPackage", new object[] {
                        user_id,
                        package_id}, this.registerPackageOperationCompleted, userState);
        }
        
        private void OnregisterPackageOperationCompleted(object arg) {
            if ((this.registerPackageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.registerPackageCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class package {
        
        private int idField;
        
        private int user_idField;
        
        private string contentField;
        
        private int statusField;
        
        /// <remarks/>
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public int user_id {
            get {
                return this.user_idField;
            }
            set {
                this.user_idField = value;
            }
        }
        
        /// <remarks/>
        public string content {
            get {
                return this.contentField;
            }
            set {
                this.contentField = value;
            }
        }
        
        /// <remarks/>
        public int status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void addPackageCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void getAllPackagesCompletedEventHandler(object sender, getAllPackagesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getAllPackagesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getAllPackagesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public package[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((package[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void registerPackageCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591