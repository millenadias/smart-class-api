
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

        AulaBLL bll = new AulaBLL();
        string connection = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        [Route("aula/ListarAulas")]
        [HttpGet]
        public HttpResponseMessage ListarAulas()
        {
   
                List <Aula> Lista = bll.ListarAulas(connection);
                return Request.CreateResponse(HttpStatusCode.OK, Lista);
        }



        [Route("aula/getAula")]
        [HttpGet]
        public HttpResponseMessage getAula(int CdAula)
        {
            Aula aula = bll.getAula(CdAula, connection);
            return Request.CreateResponse(HttpStatusCode.OK, aula);
        }


        [Route("aula/cadastrarAula")]
        [HttpPost]
        public HttpResponseMessage cadastrarAula(int CdAula, int CdDisciplina)
        {
            bll.cadastrarAula(CdAula, CdDisciplina, connection);
            return Request.CreateResponse(HttpStatusCode.OK, "A aula foi cadastrada!");
        }

        [Route("aula/cadastrarPreferenciaAula")]
        [HttpPost]
        public HttpResponseMessage cadastrarPreferenciaAula(int CdAula, int CdEquipamento, int CdPreferenciaAula)
        {
            bll.cadastrarPreferenciaAula(CdAula, CdEquipamento, CdPreferenciaAula, connection);
            return Request.CreateResponse(HttpStatusCode.OK, "A preferência de aula foi cadastrada!");
        }

        [Route("aula/excluirAula")]
        [HttpDelete]
        public HttpResponseMessage excluirAula(int CdAula)
        {
            bll.excluirAula(CdAula, connection);
            return Request.CreateResponse(HttpStatusCode.OK, "Aula excluída");
        }



    }
}