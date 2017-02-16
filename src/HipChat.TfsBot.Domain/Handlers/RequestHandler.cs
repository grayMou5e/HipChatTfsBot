using System;
using System.Text;
using System.Threading.Tasks;
using HipChat.TfsBot.Domain.ChatOptions;
using System.Net.Http;
using Newtonsoft.Json;

namespace HipChat.TfsBot.Domain.Handlers
{
    public class RequestHandler : IRequestHandler
    {
        private readonly Uri _url;
        public RequestHandler(string url)
        {
            _url = new Uri(url);
        }

        public async Task SendAsync(Color color, string message, bool notify, MessageFormat messageFormat)
        {

            var request = new HttpRequestMessage()
            {
                RequestUri = _url,
                Method = HttpMethod.Post,
                Content = new StringContent(
                    JsonConvert.SerializeObject(new { color = color.ToString(), message = message, message_format = messageFormat.ToString(), notify = notify }),
                    Encoding.UTF8,
                    "application/json")
            };

            var client = new HttpClient();
            var result = await client.SendAsync(request);

            if (!result.IsSuccessStatusCode)
            {
                throw new ApplicationException(result.StatusCode.ToString());
            }
        }
    }
}
