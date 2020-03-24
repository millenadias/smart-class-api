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
            List<Equipamento> ListaEquipamento = bll.ListarEquipamentos(codSala);
            return Request.CreateResponse(HttpStatusCode.OK, ListaEquipamento);
        }


        /*  [Route("sala/verificarDisponibilidade")]
          [HttpGet]
          public HttpRequestMessage verificarDisponibilidade(int codSala, string horario)
          {
              bool disponivel = bll.verificarDisponibilidade(codSala, horario);
              return Request.CreateResponse(HttpStatusCode.OK, disponivel);

          }*/

        [Route("sala/getSala")]
        [HttpGet]
        public HttpResponseMessage getSala (int cdSala)
        {
            Sala sala = bll.getSala(cdSala);
            return Request.CreateResponse(HttpStatusCode.OK, sala);

        }

        public void cadastrarEquipamento(int codEquipamento, int codSala)
        {
            //dal.cadastrarEquipamento(codEquipamento, codSala);
        }

        public void excluirEquipamento(int codEquipamentoSala)
        {
            //dal.excluirEquipamento(codEquipamentoSala);
        }
    }
}