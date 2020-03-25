
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartClass.Model;
using SmartClass.BLL;

namespace APISmartClass.Controllers
{
    [Serializable]
    public class AulaController : ApiController
    {
        [Route("aula/ListarAulas")]
        [HttpGet]
        public HttpResponseMessage ListarAulas()
        {
            List<Aula> listarAulas = new List<Aula>
            {
                new Aula { Sala = "B107", Hora = "21:00" },
                new Aula { Sala = "B109", Hora = "22:00" }
            };

            string connection = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

            return Request.CreateResponse(HttpStatusCode.OK, lstAula);
        }


        [Route("aula/getAula")]
        [HttpGet]
        public HttpResponseMessage getAula()
        {
            //inserir getAula
        }


        [Route("aula/cadastrarAula")]
        [HttpGet]
        public HttpResponseMessage cadastrarAula()
        {
            //inserir cadastrarAula
        }


        [Route("aula/editarAula")]
        [HttpGet]
        public HttpResponseMessage editarAula()
        {
            //inserir editarAula
        }

        [Route("aula/excluirAula")]
        [HttpGet]
        public HttpResponseMessage excluirAula()
        {
            //inserir excluirAula
        }



    }
}