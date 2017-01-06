// ---------------------------------------------------------------------------------
// <copyright file="ServiceFaultContracts.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// ---------------------------------------------------------------------------------
namespace Inflexion2.UX.WPF.Fault
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;

    /// <summary>
    /// Services for contract exceptions
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public class ServiceFaultContracts : Attribute, IContractBehavior
    {
        #region Fields

        private readonly Type[] knownFaultTypes;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// gets the info from the exception
        /// </summary>
        public ServiceFaultContracts()
        {
            this.knownFaultTypes = new Type[] { typeof(FaultObject), typeof(InternalException), typeof(ValidationException) };
        }

        /// <summary>
        /// add the info from the exception contracts
        /// </summary>
        /// <param name="knownFaultTypes"></param>
        public ServiceFaultContracts(Type[] knownFaultTypes) : this()
        {
            this.knownFaultTypes = this.knownFaultTypes.Concat(knownFaultTypes).ToArray();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// add info from the parameters in the contracts
        /// </summary>
        /// <param name="contractDescription"></param>
        /// <param name="endpoint"></param>
        /// <param name="bindingParameters"></param>
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

        /// <summary>
        /// not implemented
        /// </summary>
        /// <param name="contractDescription"></param>
        /// <param name="endpoint"></param>
        /// <param name="clientRuntime"></param>
        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            // No behavior added.
        }

        /// <summary>
        /// not implemented
        /// </summary>
        /// <param name="contractDescription"></param>
        /// <param name="endpoint"></param>
        /// <param name="dispatchRuntime"></param>
        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            // No dispatch behavior added.
        }

        /// <summary>
        /// not implemented
        /// </summary>
        /// <param name="contractDescription"></param>
        /// <param name="endpoint"></param>
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