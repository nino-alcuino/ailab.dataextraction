using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace dataextraction.Models
{
    public class Chat
    {
        public SenderEnum Sender { get; set; }
        [Required]
        public string Message { get; set; } = string.Empty;
        public IBrowserFile? FileData { get; set; }
        public byte[]? FileDataBytes { get; set; }
        public IBrowserFile? FileResult { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
