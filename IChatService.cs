using CoreWCF;

namespace PseudoRMI_ChatServer
{
    [ServiceContract(CallbackContract = typeof(IChatCallback))]
    public interface IChatService
    {
        [OperationContract]
        void SendMessage(string message);

        [OperationContract]
        void Subscribe();

        [OperationContract]
        void Unsubscribe();
    }

    public interface IChatCallback
    {
        [OperationContract]
        void ReceiveMessage(string message);
    }
}
