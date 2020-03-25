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
            List<Sala> Lista = bll.ListarSalas(connection);
            return Request.CreateResponse(HttpStatusCode.OK, Lista);
        }


        [Route("sala/ListarEquipamentos")]
        [HttpGet]
        public HttpResponseMessage ListarEquipamentos(int codSala)
        {
            List<Equipamento> ListaEquipamento = bll.ListarEquipamentos(codSala, connection);
            return Request.CreateResponse(HttpStatusCode.OK, ListaEquipamento);
        }


        [Route("sala/verificarDisponibilidade")]
        [HttpGet]
        public HttpResponseMessage verificarDisponibilidade(int codSala, string horario)
        {
            bool disponivel = bll.verificarDisponibilidade(codSala, horario, connection);
            return Request.CreateResponse(HttpStatusCode.OK, disponivel);

        }

        [Route("sala/getSala")]
        [HttpGet]
        public HttpResponseMessage getSala(int cdSala)
        {
            Sala sala = bll.getSala(cdSala, connection);
            return Request.CreateResponse(HttpStatusCode.OK, sala);

        }

        [Route("sala/cadastrarEquipamento")]
        [HttpPost]
        public HttpResponseMessage cadastrarEquipamento(int codEquipamento, int codSala)
        {
            bll.cadastrarEquipamento(codEquipamento, codSala, connection);
            return Request.CreateResponse(HttpStatusCode.OK, "Equipamento cadastrado para a sala");
        }

        [Route("sala/excluirEquipamento")]
        [HttpDelete]
        public HttpResponseMessage excluirEquipamento(int codEquipamentoSala)
        {
            bll.excluirEquipamento(codEquipamentoSala, connection);
            return Request.CreateResponse(HttpStatusCode.OK, "Equipamento excluído");
        }
    }
}