using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace APISmartClass.Controllers
{
    [Serializable]
    public class AulaController : ApiController
    {
        [Route("professor/sistemas/aulas")]
        [HttpGet]
        public HttpResponseMessage GetAulas()
        {
            List<Aula> lstAula = new List<Aula>
            {
                new Aula { Sala = "B107", Hora = "21:00" },
                new Aula { Sala = "B109", Hora = "22:00" }
            };

            string connection = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

            return Request.CreateResponse(HttpStatusCode.OK, lstAula);
        }

        public class Aula
        {
            public string Sala { get; set; }
            public string Hora { get; set; }
        }
    }
}