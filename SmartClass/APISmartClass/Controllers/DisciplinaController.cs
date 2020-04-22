
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
    public class DisciplinaController : ApiController
    {

        DisciplinaBLL bll = new DisciplinaBLL();
        string connection = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        [Route("disciplina/ListarDisciplinas")]
        [HttpGet]
        public HttpResponseMessage ListarDisciplinas()
        {
            try
            {
                List<Disciplina> lstDisciplina = bll.ListarDisciplinas(connection);
                return Request.CreateResponse(HttpStatusCode.OK, lstDisciplina);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


       

    }
}