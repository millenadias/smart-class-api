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
    public class TurmaController : ApiController
    {
        string connection = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        TurmaBLL bll = new TurmaBLL();

        [Route("turma/Inserir")]
        [HttpPost]
        public HttpResponseMessage Inserir(Turma turma)
        {
            try
            {
                bll.Inserir(turma, connection);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("turma/InserirAlunoTurma")]
        [HttpPost]
        public HttpResponseMessage InserirAlunoTurma(int pCdAluno, int pCdTurma)
        {
            try
            {
                bll.InserirAlunoTurma(pCdAluno, pCdTurma, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "Aluno cadastrado para a turma");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("turma/AlterarTurma")]
        [HttpPut]
        public HttpResponseMessage AlterarTurma(Turma turma)
        {
            try
            {
                bll.AlterarTurma(turma, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "Turma alterada");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("turma/ListarTurmas")]
        [HttpGet]
        public HttpResponseMessage ListarTurmas()
        {
            try
            {
                List<Turma> turmas = bll.ListarTurmas(connection);
                return Request.CreateResponse(HttpStatusCode.OK, turmas);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}