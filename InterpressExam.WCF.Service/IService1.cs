using System.ServiceModel;

namespace InterpressExam.WCF.Service
{    
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        void FireDatabaseEvents();

        [OperationContract]
        void BroadcastToClients();
    } 
}
