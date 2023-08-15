using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using dataextraction.Models;
using OfficeOpenXml;
using MudBlazor;

namespace dataextraction.Services
{
    public class DataExtractionService : IDataExtractionService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;
        private readonly IChatService _chatService;
        private readonly string _token;
        private readonly string _AiURL;
        public DataExtractionService(HttpClient http, IConfiguration configuration, IChatService chatService)
        {
            _http = http;
            _configuration = configuration;
            _chatService = chatService;
            _token = _configuration.GetSection("VertixAIOptions:Token").Value;
            _AiURL = _configuration.GetSection("VertixAIOptions:Url").Value;
        }

        public async Task<string> SendToAI(Chat chat)
        {
            var message = chat.Message;
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _AiURL);

            var body = new Dictionary<string, object>
            {
                ["instances"] = new List<object>
                {
                    new Dictionary<string, object>
                    {
                        ["prefix"] = message
                    }
                },
                ["parameters"] = new Dictionary<string, object>
                {
                    ["temperature"] = 0.2,
                    ["maxOutputTokens"] = 1024
                }
            };

            request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8);

            HttpResponseMessage response = await _http.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<VertexAIResponse>();


                _chatService.AddMessage(responseBody?.predictions?.FirstOrDefault()?.content ?? "", SenderEnum.AI);
                return responseBody?.predictions?.FirstOrDefault()?.content ?? "";
            }
            else
            {
                _chatService.AddMessage("You do not have the necessary permissions to perform this action.", SenderEnum.AI);
                return "An error occurred: " + response.StatusCode;
            }
        }

        public async Task<string> SendToAIWithFile(Chat chat)
        {
            var file = chat.FileData;
            if(file == null)
                return await SendToAI(chat);

            var path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            await using var fs = new FileStream(path, FileMode.Create);
            await file.OpenReadStream(file.Size).CopyToAsync(fs);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage(fs);
            using var writer = new StreamWriter("output.txt");

            //get the first worksheet in the workbook
            ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
            int colCount = worksheet.Dimension.End.Column;  //get Column Count
            int rowCount = worksheet.Dimension.End.Row;     //get row count
            for (int row = 1; row <= rowCount; row++)
            {
                for (int col = 1; col <= colCount; col++)
                {
                    string value = worksheet.Cells[row, col].Value.ToString() ?? "";
                    writer.WriteLine($" Row:{row} column:{col} Value:{value.Trim()}");
                }
            }
            writer.Close();
            var fileText = File.ReadAllText("output.txt");
            
            return await SendToAI(chat);
        }
    }
}
