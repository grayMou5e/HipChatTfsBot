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
        //[Route("pullRequest/{id}")]
        public async Task<IHttpActionResult> PullRequest([FromUri]int id)
        {
            return Ok(id);
        } 
    }
}
