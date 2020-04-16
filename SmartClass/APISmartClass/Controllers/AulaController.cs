
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

            try
            {
                List<Aula> Lista = bll.ListarAulas(connection);
                return Request.CreateResponse(HttpStatusCode.OK, Lista);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        [Route("aula/getAula")]
        [HttpGet]
        public HttpResponseMessage getAula(int CdAula)
        {
            try
            {
                Aula aula = bll.getAula(CdAula, connection);
                return Request.CreateResponse(HttpStatusCode.OK, aula);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [Route("aula/alterarAula")]
        [HttpPut]
        public HttpResponseMessage alterarAula(Aula aula)
        {
            bll.alterarAula(aula, connection);
            return Request.CreateResponse(HttpStatusCode.OK, "A aula foi alterada!");
        }

        [Route("aula/cadastrarAula")]
        [HttpPost]
        public HttpResponseMessage cadastrarAula(Aula aula)
        {
            try
            {
                bll.cadastrarAula(aula, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "A aula foi cadastrada!");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("aula/cadastrarPreferenciaAula")]
        [HttpPost]
        public HttpResponseMessage cadastrarPreferenciaAula(int CdAula, int CdEquipamento)
        {
            try
            {
                bll.cadastrarPreferenciaAula(CdAula, CdEquipamento, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "A preferência de aula foi cadastrada!");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("aula/excluirAula")]
        [HttpDelete]
        public HttpResponseMessage excluirAula(int CdAula)
        {
            try
            {
                bll.excluirAula(CdAula, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "Aula excluída");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("aula/excluirPreferenciaAula")]
        [HttpDelete]
        public HttpResponseMessage excluirPreferenciaAula(int CdPreferenciaAula)
        {
            bll.excluirPreferenciaAula(CdPreferenciaAula, connection);
            return Request.CreateResponse(HttpStatusCode.OK, "Preferencia excluída");
        }


       

    }
}