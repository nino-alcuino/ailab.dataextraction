using dataextraction.Models;

namespace dataextraction.Services
{
    public interface IChatService
    {
        event Action OnChange;
        List<Chat> Messages { get; set; }
        void AddMessage(string message, SenderEnum sender);
        void RemoveMessages();
    }
}
