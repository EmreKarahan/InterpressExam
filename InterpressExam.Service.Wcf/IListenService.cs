using System.ServiceModel;

namespace InterpressExam.Service.Wcf
{    
    [ServiceContract]
    public interface IListenService
    {

        [OperationContract]
        void FireDatabaseEvents();

        [OperationContract]
        void BroadcastToClients();
    } 
}
