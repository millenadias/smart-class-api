using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartClass.Model;
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
            //usar a classe Aula que foi criada em SmartClass.Model - Aula.cs
            Aula aula = new Aula();
            List<Aula> lstAula = new List<Aula>
            {
               aula
            };
            return Request.CreateResponse(HttpStatusCode.OK, lstAula);
        }

       /* public class Aula
        {
            public string Sala { get; set; }
            public string Hora { get; set; }
        }*/
    }
}