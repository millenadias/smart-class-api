using SmartClass.BLL;
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
    public class EquipamentoController: ApiController
    {
        EquipamentoBLL bll = new EquipamentoBLL();
        string connection = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        [Route("equipamento/Inserir")]
        [HttpPost]
        public HttpResponseMessage Inserir(String pDsEquipamento)
        {
            bll.Inserir(pDsEquipamento);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("equipamento/Alterar")]
        [HttpPut]
        public HttpResponseMessage Alterar(Equipamento eqpto)
        {
            bll.Alterar(eqpto);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("equipamento/Excluir")]
        [HttpDelete]
        public HttpResponseMessage Excluir(int pCdEquipamento)
        {
            bll.Excluir(pCdEquipamento);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("equipamento/ListarEquipamentos")]
        [HttpGet]
        public HttpResponseMessage ListarEquipamentos()
        {
            List<Equipamento> lst = bll.ListarEquipamentos();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        [Route("equipamento/ligarEquipamento")]
        [HttpGet]
        public HttpResponseMessage ligarEquipamento(int CdAula, int CdEquipamento)
        {
            try
            {
                bool ligar = bll.ligarEquipamento(CdEquipamento, CdAula, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "Ligar Equipamento: " + ligar.ToString());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}