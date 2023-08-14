using dataextraction.Models;
using Microsoft.AspNetCore.Http;

namespace dataextraction.Services
{
    public interface IDataExtractionService
    {
        Task<string> SendToAI(Chat chat);
        Task<string> SendToAIWithFile(Chat chat);
    }
}
