using System;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using SmartClass.Model;
using SmartClass.BLL;
using System.Collections.Generic;

namespace APISmartClass.Controllers
{
    [Serializable]
    public class SalaController : ApiController
    {
        SalaBLL bll = new SalaBLL();
        string connection = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        [Route("sala/ListarSalas")]
        [HttpGet]
        public HttpResponseMessage ListarSalas()
        {
            try
            {
                List<Sala> Lista = bll.ListarSalas(connection);
                return Request.CreateResponse(HttpStatusCode.OK, Lista);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [Route("sala/ListarEquipamentos")]
        [HttpGet]
        public HttpResponseMessage ListarEquipamentos(int codSala)
        {
            try
            {
                List<Equipamento> ListaEquipamento = bll.ListarEquipamentos(codSala, connection);
                return Request.CreateResponse(HttpStatusCode.OK, ListaEquipamento);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [Route("sala/verificarDisponibilidade")]
        [HttpGet]
        public HttpResponseMessage verificarDisponibilidade(int codSala, string horario)
        {
            try
            {
                bool disponivel = bll.verificarDisponibilidade(codSala, horario, connection);
                return Request.CreateResponse(HttpStatusCode.OK, disponivel);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [Route("sala/getSala")]
        [HttpGet]
        public HttpResponseMessage getSala(int cdSala)
        {
            try
            {
                Sala sala = bll.getSala(cdSala, connection);
                return Request.CreateResponse(HttpStatusCode.OK, sala);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [Route("sala/cadastrarEquipamento")]
        [HttpPost]
        public HttpResponseMessage cadastrarEquipamento(int codEquipamento, int codSala)
        {
            try
            {
                bll.cadastrarEquipamento(codEquipamento, codSala, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "Equipamento cadastrado para a sala");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("sala/excluirEquipamento")]
        [HttpDelete]
        public HttpResponseMessage excluirEquipamento(int codEquipamentoSala)
        {
            try
            {
                bll.excluirEquipamento(codEquipamentoSala, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "Equipamento excluído");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}