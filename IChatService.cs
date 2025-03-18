using System.Threading.Tasks;

public interface IChatService
{
    Task SendMessage(string user, string message);
}