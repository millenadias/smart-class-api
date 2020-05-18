
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

        [Route("aula/ListarAulasProfessor")]
        [HttpGet]
        public HttpResponseMessage ListarAulasProfessor(int pCdProfessor)
        {

            try
            {
                List<Aula> Lista = bll.ListarAulasProfessor(pCdProfessor, connection);
                return Request.CreateResponse(HttpStatusCode.OK, Lista);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("aula/ListarAulasDiaProfessor")]
        [HttpGet]
        public HttpResponseMessage ListarAulasDiaProfessor(int pCdProfessor)
        {

            try
            {
                List<Aula> Lista = bll.ListarAulasDiaProfessor(pCdProfessor, connection);
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
            try
            {
                bll.alterarAula(aula, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "A aula foi alterada!");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Aula não alterada.");
                throw;
            }
        }

        [Route("aula/cadastrarAula")]
        [HttpPost]
        public HttpResponseMessage cadastrarAula(Aula aula)
        {
            try
            {
                int codigoAula = bll.cadastrarAula(aula, connection);
                return Request.CreateResponse(HttpStatusCode.OK, codigoAula);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, 0);
            }
        }


        [Route("aula/cadastrarPreferenciasAula")]
        [HttpPost]
        public HttpResponseMessage cadastrarPreferenciasAula(int CdAula, int[] equipamentos)
        {
            try
            {
                bll.cadastrarPreferenciasAula(CdAula, equipamentos.ToList(), connection);
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

        [Route("aula/ValidarAulaPermitida")]
        [HttpGet]
        public HttpResponseMessage ValidarAulaPermitida(int cdSala, DateTime dtIni, DateTime dtFim)
        {
            try
            {
                bool aulaPermitida = bll.ValidarAulaPermitida(cdSala, dtIni, dtFim, connection);
                return Request.CreateResponse(HttpStatusCode.OK, aulaPermitida);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("aula/ListarPreferencias")]
        [HttpGet]
        public HttpResponseMessage ListarPreferencias(int cdAula)
        {
            try
            {
                List<int> preferencias = bll.ListarPreferencias(cdAula, connection);
                return Request.CreateResponse(HttpStatusCode.OK, preferencias);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



    }
}