using HipChat.TfsBot.Domain.ChatOptions;
using HipChat.TfsBot.Domain.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace hiptfsbot.Controllers
{
    public class TfsController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> PullRequest([FromUri]int id, [FromBody]PullRequest pullRequest)
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://vp-wolfpack.hipchat.com/v2/room/3580924/notification?auth_token=jejjmkh5qysDkb9cCPn4q4UurMWDxhOlj9Di9WQ2"),
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(
                    new { color = Color.red.ToString(), message = pullRequest.detailedMessage.html, notify = true, message_format = MessageFormat.html.ToString()}),
                    System.Text.Encoding.UTF8, 
                    "application/json")

            };

            var client = new HttpClient();
            var result = await client.SendAsync(request);

            return Ok();
        }
    }
}
