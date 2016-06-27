

namespace WCFFromClassLibrary
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IHellowWorldService
    {
        [OperationContract]
        string GetMessage(string name);

        
    }
}
