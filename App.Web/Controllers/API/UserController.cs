using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App.Web.Controllers.API
{
    /// <summary>
    /// Sample controller for Web API
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// Sample Get method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = "This is a sample !"});
        }
    }
}