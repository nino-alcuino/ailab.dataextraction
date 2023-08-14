using Microsoft.AspNetCore.Components.Forms;

namespace dataextraction.Models
{
    public static class FormFileExtensions
    {
        public static async Task<byte[]> GetBytes(this IBrowserFile formFile)
        {
            return await formFile.GetBytes();
        }
    }
}
