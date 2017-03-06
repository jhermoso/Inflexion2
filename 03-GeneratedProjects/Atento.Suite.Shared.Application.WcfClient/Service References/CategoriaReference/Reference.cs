﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Atento.Suite.Shared.Application.WcfClient.CategoriaReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CategoriaReference.ICategoriaService")]
    public interface ICategoriaService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoriaService/Create", ReplyAction="http://tempuri.org/ICategoriaService/CreateResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.FaultObject), Action="http://tempuri.org/ICategoriaService/CreateFaultObjectFault", Name="FaultObject", Namespace="")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.ValidationException), Action="http://tempuri.org/ICategoriaService/CreateValidationExceptionFault", Name="ValidationException", Namespace="")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.InternalException), Action="http://tempuri.org/ICategoriaService/CreateInternalExceptionFault", Name="InternalException", Namespace="")]
        int Create(Atento.Suite.Shared.Application.Dtos.CategoriaDto categoriaDto);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/ICategoriaService/Create", ReplyAction="http://tempuri.org/ICategoriaService/CreateResponse")]
        System.IAsyncResult BeginCreate(Atento.Suite.Shared.Application.Dtos.CategoriaDto categoriaDto, System.AsyncCallback callback, object asyncState);
        
        int EndCreate(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoriaService/Update", ReplyAction="http://tempuri.org/ICategoriaService/UpdateResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.FaultObject), Action="http://tempuri.org/ICategoriaService/UpdateFaultObjectFault", Name="FaultObject", Namespace="")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.ValidationException), Action="http://tempuri.org/ICategoriaService/UpdateValidationExceptionFault", Name="ValidationException", Namespace="")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.InternalException), Action="http://tempuri.org/ICategoriaService/UpdateInternalExceptionFault", Name="InternalException", Namespace="")]
        bool Update(Atento.Suite.Shared.Application.Dtos.CategoriaDto categoriaDto);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/ICategoriaService/Update", ReplyAction="http://tempuri.org/ICategoriaService/UpdateResponse")]
        System.IAsyncResult BeginUpdate(Atento.Suite.Shared.Application.Dtos.CategoriaDto categoriaDto, System.AsyncCallback callback, object asyncState);
        
        bool EndUpdate(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoriaService/Delete", ReplyAction="http://tempuri.org/ICategoriaService/DeleteResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.FaultObject), Action="http://tempuri.org/ICategoriaService/DeleteFaultObjectFault", Name="FaultObject", Namespace="")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.ValidationException), Action="http://tempuri.org/ICategoriaService/DeleteValidationExceptionFault", Name="ValidationException", Namespace="")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.InternalException), Action="http://tempuri.org/ICategoriaService/DeleteInternalExceptionFault", Name="InternalException", Namespace="")]
        bool Delete(int id);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/ICategoriaService/Delete", ReplyAction="http://tempuri.org/ICategoriaService/DeleteResponse")]
        System.IAsyncResult BeginDelete(int id, System.AsyncCallback callback, object asyncState);
        
        bool EndDelete(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoriaService/GetAll", ReplyAction="http://tempuri.org/ICategoriaService/GetAllResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.FaultObject), Action="http://tempuri.org/ICategoriaService/GetAllFaultObjectFault", Name="FaultObject", Namespace="")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.ValidationException), Action="http://tempuri.org/ICategoriaService/GetAllValidationExceptionFault", Name="ValidationException", Namespace="")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.InternalException), Action="http://tempuri.org/ICategoriaService/GetAllInternalExceptionFault", Name="InternalException", Namespace="")]
        System.Collections.ObjectModel.ObservableCollection<Atento.Suite.Shared.Application.Dtos.CategoriaDto> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/ICategoriaService/GetAll", ReplyAction="http://tempuri.org/ICategoriaService/GetAllResponse")]
        System.IAsyncResult BeginGetAll(System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<Atento.Suite.Shared.Application.Dtos.CategoriaDto> EndGetAll(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoriaService/GetById", ReplyAction="http://tempuri.org/ICategoriaService/GetByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.FaultObject), Action="http://tempuri.org/ICategoriaService/GetByIdFaultObjectFault", Name="FaultObject", Namespace="")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.ValidationException), Action="http://tempuri.org/ICategoriaService/GetByIdValidationExceptionFault", Name="ValidationException", Namespace="")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.InternalException), Action="http://tempuri.org/ICategoriaService/GetByIdInternalExceptionFault", Name="InternalException", Namespace="")]
        Atento.Suite.Shared.Application.Dtos.CategoriaDto GetById(int categoriaId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/ICategoriaService/GetById", ReplyAction="http://tempuri.org/ICategoriaService/GetByIdResponse")]
        System.IAsyncResult BeginGetById(int categoriaId, System.AsyncCallback callback, object asyncState);
        
        Atento.Suite.Shared.Application.Dtos.CategoriaDto EndGetById(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoriaService/GetPaged", ReplyAction="http://tempuri.org/ICategoriaService/GetPagedResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.FaultObject), Action="http://tempuri.org/ICategoriaService/GetPagedFaultObjectFault", Name="FaultObject", Namespace="")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.ValidationException), Action="http://tempuri.org/ICategoriaService/GetPagedValidationExceptionFault", Name="ValidationException", Namespace="")]
        [System.ServiceModel.FaultContractAttribute(typeof(Inflexion2.Application.InternalException), Action="http://tempuri.org/ICategoriaService/GetPagedInternalExceptionFault", Name="InternalException", Namespace="")]
        Inflexion2.Domain.PagedElements<Atento.Suite.Shared.Application.Dtos.CategoriaDto> GetPaged(Inflexion2.Application.SpecificationDto specificationDto);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/ICategoriaService/GetPaged", ReplyAction="http://tempuri.org/ICategoriaService/GetPagedResponse")]
        System.IAsyncResult BeginGetPaged(Inflexion2.Application.SpecificationDto specificationDto, System.AsyncCallback callback, object asyncState);
        
        Inflexion2.Domain.PagedElements<Atento.Suite.Shared.Application.Dtos.CategoriaDto> EndGetPaged(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICategoriaServiceChannel : Atento.Suite.Shared.Application.WcfClient.CategoriaReference.ICategoriaService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public CreateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UpdateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public UpdateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DeleteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public DeleteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetAllCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetAllCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Atento.Suite.Shared.Application.Dtos.CategoriaDto> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<Atento.Suite.Shared.Application.Dtos.CategoriaDto>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetByIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetByIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Atento.Suite.Shared.Application.Dtos.CategoriaDto Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Atento.Suite.Shared.Application.Dtos.CategoriaDto)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetPagedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetPagedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Inflexion2.Domain.PagedElements<Atento.Suite.Shared.Application.Dtos.CategoriaDto> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Inflexion2.Domain.PagedElements<Atento.Suite.Shared.Application.Dtos.CategoriaDto>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CategoriaServiceClient : System.ServiceModel.ClientBase<Atento.Suite.Shared.Application.WcfClient.CategoriaReference.ICategoriaService>, Atento.Suite.Shared.Application.WcfClient.CategoriaReference.ICategoriaService {
        
        private BeginOperationDelegate onBeginCreateDelegate;
        
        private EndOperationDelegate onEndCreateDelegate;
        
        private System.Threading.SendOrPostCallback onCreateCompletedDelegate;
        
        private BeginOperationDelegate onBeginUpdateDelegate;
        
        private EndOperationDelegate onEndUpdateDelegate;
        
        private System.Threading.SendOrPostCallback onUpdateCompletedDelegate;
        
        private BeginOperationDelegate onBeginDeleteDelegate;
        
        private EndOperationDelegate onEndDeleteDelegate;
        
        private System.Threading.SendOrPostCallback onDeleteCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetAllDelegate;
        
        private EndOperationDelegate onEndGetAllDelegate;
        
        private System.Threading.SendOrPostCallback onGetAllCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetByIdDelegate;
        
        private EndOperationDelegate onEndGetByIdDelegate;
        
        private System.Threading.SendOrPostCallback onGetByIdCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetPagedDelegate;
        
        private EndOperationDelegate onEndGetPagedDelegate;
        
        private System.Threading.SendOrPostCallback onGetPagedCompletedDelegate;
        
        public CategoriaServiceClient() {
        }
        
        public CategoriaServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CategoriaServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CategoriaServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CategoriaServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<CreateCompletedEventArgs> CreateCompleted;
        
        public event System.EventHandler<UpdateCompletedEventArgs> UpdateCompleted;
        
        public event System.EventHandler<DeleteCompletedEventArgs> DeleteCompleted;
        
        public event System.EventHandler<GetAllCompletedEventArgs> GetAllCompleted;
        
        public event System.EventHandler<GetByIdCompletedEventArgs> GetByIdCompleted;
        
        public event System.EventHandler<GetPagedCompletedEventArgs> GetPagedCompleted;
        
        public int Create(Atento.Suite.Shared.Application.Dtos.CategoriaDto categoriaDto) {
            return base.Channel.Create(categoriaDto);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginCreate(Atento.Suite.Shared.Application.Dtos.CategoriaDto categoriaDto, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginCreate(categoriaDto, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public int EndCreate(System.IAsyncResult result) {
            return base.Channel.EndCreate(result);
        }
        
        private System.IAsyncResult OnBeginCreate(object[] inValues, System.AsyncCallback callback, object asyncState) {
            Atento.Suite.Shared.Application.Dtos.CategoriaDto categoriaDto = ((Atento.Suite.Shared.Application.Dtos.CategoriaDto)(inValues[0]));
            return this.BeginCreate(categoriaDto, callback, asyncState);
        }
        
        private object[] OnEndCreate(System.IAsyncResult result) {
            int retVal = this.EndCreate(result);
            return new object[] {
                    retVal};
        }
        
        private void OnCreateCompleted(object state) {
            if ((this.CreateCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CreateCompleted(this, new CreateCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CreateAsync(Atento.Suite.Shared.Application.Dtos.CategoriaDto categoriaDto) {
            this.CreateAsync(categoriaDto, null);
        }
        
        public void CreateAsync(Atento.Suite.Shared.Application.Dtos.CategoriaDto categoriaDto, object userState) {
            if ((this.onBeginCreateDelegate == null)) {
                this.onBeginCreateDelegate = new BeginOperationDelegate(this.OnBeginCreate);
            }
            if ((this.onEndCreateDelegate == null)) {
                this.onEndCreateDelegate = new EndOperationDelegate(this.OnEndCreate);
            }
            if ((this.onCreateCompletedDelegate == null)) {
                this.onCreateCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCreateCompleted);
            }
            base.InvokeAsync(this.onBeginCreateDelegate, new object[] {
                        categoriaDto}, this.onEndCreateDelegate, this.onCreateCompletedDelegate, userState);
        }
        
        public bool Update(Atento.Suite.Shared.Application.Dtos.CategoriaDto categoriaDto) {
            return base.Channel.Update(categoriaDto);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginUpdate(Atento.Suite.Shared.Application.Dtos.CategoriaDto categoriaDto, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUpdate(categoriaDto, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndUpdate(System.IAsyncResult result) {
            return base.Channel.EndUpdate(result);
        }
        
        private System.IAsyncResult OnBeginUpdate(object[] inValues, System.AsyncCallback callback, object asyncState) {
            Atento.Suite.Shared.Application.Dtos.CategoriaDto categoriaDto = ((Atento.Suite.Shared.Application.Dtos.CategoriaDto)(inValues[0]));
            return this.BeginUpdate(categoriaDto, callback, asyncState);
        }
        
        private object[] OnEndUpdate(System.IAsyncResult result) {
            bool retVal = this.EndUpdate(result);
            return new object[] {
                    retVal};
        }
        
        private void OnUpdateCompleted(object state) {
            if ((this.UpdateCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateCompleted(this, new UpdateCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UpdateAsync(Atento.Suite.Shared.Application.Dtos.CategoriaDto categoriaDto) {
            this.UpdateAsync(categoriaDto, null);
        }
        
        public void UpdateAsync(Atento.Suite.Shared.Application.Dtos.CategoriaDto categoriaDto, object userState) {
            if ((this.onBeginUpdateDelegate == null)) {
                this.onBeginUpdateDelegate = new BeginOperationDelegate(this.OnBeginUpdate);
            }
            if ((this.onEndUpdateDelegate == null)) {
                this.onEndUpdateDelegate = new EndOperationDelegate(this.OnEndUpdate);
            }
            if ((this.onUpdateCompletedDelegate == null)) {
                this.onUpdateCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateDelegate, new object[] {
                        categoriaDto}, this.onEndUpdateDelegate, this.onUpdateCompletedDelegate, userState);
        }
        
        public bool Delete(int id) {
            return base.Channel.Delete(id);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginDelete(int id, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDelete(id, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndDelete(System.IAsyncResult result) {
            return base.Channel.EndDelete(result);
        }
        
        private System.IAsyncResult OnBeginDelete(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int id = ((int)(inValues[0]));
            return this.BeginDelete(id, callback, asyncState);
        }
        
        private object[] OnEndDelete(System.IAsyncResult result) {
            bool retVal = this.EndDelete(result);
            return new object[] {
                    retVal};
        }
        
        private void OnDeleteCompleted(object state) {
            if ((this.DeleteCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DeleteCompleted(this, new DeleteCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DeleteAsync(int id) {
            this.DeleteAsync(id, null);
        }
        
        public void DeleteAsync(int id, object userState) {
            if ((this.onBeginDeleteDelegate == null)) {
                this.onBeginDeleteDelegate = new BeginOperationDelegate(this.OnBeginDelete);
            }
            if ((this.onEndDeleteDelegate == null)) {
                this.onEndDeleteDelegate = new EndOperationDelegate(this.OnEndDelete);
            }
            if ((this.onDeleteCompletedDelegate == null)) {
                this.onDeleteCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDeleteCompleted);
            }
            base.InvokeAsync(this.onBeginDeleteDelegate, new object[] {
                        id}, this.onEndDeleteDelegate, this.onDeleteCompletedDelegate, userState);
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Atento.Suite.Shared.Application.Dtos.CategoriaDto> GetAll() {
            return base.Channel.GetAll();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetAll(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetAll(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.ObjectModel.ObservableCollection<Atento.Suite.Shared.Application.Dtos.CategoriaDto> EndGetAll(System.IAsyncResult result) {
            return base.Channel.EndGetAll(result);
        }
        
        private System.IAsyncResult OnBeginGetAll(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetAll(callback, asyncState);
        }
        
        private object[] OnEndGetAll(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<Atento.Suite.Shared.Application.Dtos.CategoriaDto> retVal = this.EndGetAll(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetAllCompleted(object state) {
            if ((this.GetAllCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetAllCompleted(this, new GetAllCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetAllAsync() {
            this.GetAllAsync(null);
        }
        
        public void GetAllAsync(object userState) {
            if ((this.onBeginGetAllDelegate == null)) {
                this.onBeginGetAllDelegate = new BeginOperationDelegate(this.OnBeginGetAll);
            }
            if ((this.onEndGetAllDelegate == null)) {
                this.onEndGetAllDelegate = new EndOperationDelegate(this.OnEndGetAll);
            }
            if ((this.onGetAllCompletedDelegate == null)) {
                this.onGetAllCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetAllCompleted);
            }
            base.InvokeAsync(this.onBeginGetAllDelegate, null, this.onEndGetAllDelegate, this.onGetAllCompletedDelegate, userState);
        }
        
        public Atento.Suite.Shared.Application.Dtos.CategoriaDto GetById(int categoriaId) {
            return base.Channel.GetById(categoriaId);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetById(int categoriaId, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetById(categoriaId, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Atento.Suite.Shared.Application.Dtos.CategoriaDto EndGetById(System.IAsyncResult result) {
            return base.Channel.EndGetById(result);
        }
        
        private System.IAsyncResult OnBeginGetById(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int categoriaId = ((int)(inValues[0]));
            return this.BeginGetById(categoriaId, callback, asyncState);
        }
        
        private object[] OnEndGetById(System.IAsyncResult result) {
            Atento.Suite.Shared.Application.Dtos.CategoriaDto retVal = this.EndGetById(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetByIdCompleted(object state) {
            if ((this.GetByIdCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetByIdCompleted(this, new GetByIdCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetByIdAsync(int categoriaId) {
            this.GetByIdAsync(categoriaId, null);
        }
        
        public void GetByIdAsync(int categoriaId, object userState) {
            if ((this.onBeginGetByIdDelegate == null)) {
                this.onBeginGetByIdDelegate = new BeginOperationDelegate(this.OnBeginGetById);
            }
            if ((this.onEndGetByIdDelegate == null)) {
                this.onEndGetByIdDelegate = new EndOperationDelegate(this.OnEndGetById);
            }
            if ((this.onGetByIdCompletedDelegate == null)) {
                this.onGetByIdCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetByIdCompleted);
            }
            base.InvokeAsync(this.onBeginGetByIdDelegate, new object[] {
                        categoriaId}, this.onEndGetByIdDelegate, this.onGetByIdCompletedDelegate, userState);
        }
        
        public Inflexion2.Domain.PagedElements<Atento.Suite.Shared.Application.Dtos.CategoriaDto> GetPaged(Inflexion2.Application.SpecificationDto specificationDto) {
            return base.Channel.GetPaged(specificationDto);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetPaged(Inflexion2.Application.SpecificationDto specificationDto, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetPaged(specificationDto, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Inflexion2.Domain.PagedElements<Atento.Suite.Shared.Application.Dtos.CategoriaDto> EndGetPaged(System.IAsyncResult result) {
            return base.Channel.EndGetPaged(result);
        }
        
        private System.IAsyncResult OnBeginGetPaged(object[] inValues, System.AsyncCallback callback, object asyncState) {
            Inflexion2.Application.SpecificationDto specificationDto = ((Inflexion2.Application.SpecificationDto)(inValues[0]));
            return this.BeginGetPaged(specificationDto, callback, asyncState);
        }
        
        private object[] OnEndGetPaged(System.IAsyncResult result) {
            Inflexion2.Domain.PagedElements<Atento.Suite.Shared.Application.Dtos.CategoriaDto> retVal = this.EndGetPaged(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetPagedCompleted(object state) {
            if ((this.GetPagedCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetPagedCompleted(this, new GetPagedCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetPagedAsync(Inflexion2.Application.SpecificationDto specificationDto) {
            this.GetPagedAsync(specificationDto, null);
        }
        
        public void GetPagedAsync(Inflexion2.Application.SpecificationDto specificationDto, object userState) {
            if ((this.onBeginGetPagedDelegate == null)) {
                this.onBeginGetPagedDelegate = new BeginOperationDelegate(this.OnBeginGetPaged);
            }
            if ((this.onEndGetPagedDelegate == null)) {
                this.onEndGetPagedDelegate = new EndOperationDelegate(this.OnEndGetPaged);
            }
            if ((this.onGetPagedCompletedDelegate == null)) {
                this.onGetPagedCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetPagedCompleted);
            }
            base.InvokeAsync(this.onBeginGetPagedDelegate, new object[] {
                        specificationDto}, this.onEndGetPagedDelegate, this.onGetPagedCompletedDelegate, userState);
        }
    }
}
