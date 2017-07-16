using System.ServiceModel;

namespace InterpressExam.Service.Wcf.Service
{    
    [ServiceContract]
    public interface IListenService
    {

        [OperationContract]
        void FireDatabaseEvents();

        //[OperationContract]
        //void BroadcastToClients();
    } 
}
