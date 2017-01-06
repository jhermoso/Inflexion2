// ---------------------------------------------------------------------------------
// <copyright file="ServiceFaultContracts.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// ---------------------------------------------------------------------------------
namespace Inflexion.UX.WPF.Fault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using System.Text;

    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public class ServiceFaultContracts : Attribute, IContractBehavior
    {
        #region Fields

        private readonly Type[] knownFaultTypes;

        #endregion Fields

        #region Constructors

        public ServiceFaultContracts()
        {
            this.knownFaultTypes = new Type[] { typeof(FaultObject), typeof(InternalException), typeof(ValidationException) };
        }

        public ServiceFaultContracts(Type[] knownFaultTypes) : this()
        {
            this.knownFaultTypes = this.knownFaultTypes.Concat(knownFaultTypes).ToArray();
        }

        #endregion Constructors

        #region Methods

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            foreach (var op in contractDescription.Operations)
            {
                foreach (var knownFaultType in knownFaultTypes)
                {
                    // Add fault contract if it is not yet present
                    if (!op.Faults.Any(f => f.DetailType == knownFaultType))
                    {
                        op.Faults.Add(new FaultDescription(knownFaultType.Name)
                        {
                            DetailType = knownFaultType, Name = knownFaultType.Name
                        });
                    }
                }
            }
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            // No behavior added.
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            // No dispatch behavior added.
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
            var badType = knownFaultTypes.FirstOrDefault(t => !t.IsDefined(typeof(DataContractAttribute), true));
            if (badType != null)
            {
                throw new ArgumentException(string.Format("The specified fault '{0}' is no data contract. Did you forget to decorate the class with the DataContractAttirbute attribute?", badType));
            }
        }

        #endregion Methods
    }
}