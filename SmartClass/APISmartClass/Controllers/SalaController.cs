using System;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using SmartClass.Model;

namespace APISmartClass.Controllers
{
    [Serializable]
    public class SalaController : ApiController
    {
        [Route("professor/sistemas/salas")]
        [HttpGet]
        public HttpResponseMessage GetSalas()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new Sala());
        }
    }
}