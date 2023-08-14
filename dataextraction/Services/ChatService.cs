using dataextraction.Models;

namespace dataextraction.Services
{
    public class ChatService : IChatService
    {
        public List<Chat> Messages { get; set; } = new List<Chat>();

        public event Action OnChange = null!;

        public void AddMessage(string message, SenderEnum sender)
        {
            Messages.Add(new Chat 
            { 
                Sender = sender, 
                Message = message, 
                DateCreated = DateTime.Now 
            });

            OnChange?.Invoke();
        }

        public void RemoveMessages()
        {
            Messages.Clear();

            OnChange?.Invoke();
        }
    }
}
