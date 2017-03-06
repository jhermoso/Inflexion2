namespace Inflexion2.Application
{
    using System.Runtime.Serialization;
    using System.ServiceModel;

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class InternalFault
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Description { get; set; }
    }
    
}
