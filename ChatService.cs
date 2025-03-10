using CoreWCF;

namespace PseudoRMI_ChatServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        private List<IChatCallback> clients = new List<IChatCallback>();

        public void SendMessage(string message)
        {
            foreach (var client in clients)
            {
                client.ReceiveMessage(message);
            }
        }

        public void Subscribe()
        {
            IChatCallback client = OperationContext.Current.GetCallbackChannel<IChatCallback>();
            if (!clients.Contains(client))
            {
                clients.Add(client);
            }
        }

        public void Unsubscribe()
        {
            IChatCallback client = OperationContext.Current.GetCallbackChannel<IChatCallback>();
            if (clients.Contains(client))
            {
                clients.Remove(client);
            }
        }
    }
}
