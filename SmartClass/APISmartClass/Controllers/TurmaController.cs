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
    public class TurmaController: ApiController
    {
        string connection = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        TurmaBLL bll = new TurmaBLL();

        [Route("turma/Inserir")]
        [HttpPost]
        public HttpResponseMessage Inserir(Turma turma)
        {
            bll.Inserir(turma, connection);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("turma/InserirAlunoTurma")]
        [HttpPost]
        public HttpResponseMessage InserirAlunoTurma(int pCdAluno, int pCdTurma)
        {
            bll.InserirAlunoTurma(pCdAluno, pCdTurma, connection);
            return Request.CreateResponse(HttpStatusCode.OK, "Aluno cadastrado para a turma");
        }

        [Route("turma/AlterarTurma")]
        [HttpPut]
        public HttpResponseMessage AlterarTurma(Turma turma)
        {
            bll.AlterarTurma(turma, connection);
            return Request.CreateResponse(HttpStatusCode.OK, "Turma alterada");
        }

        [Route("turma/ListarTurmas")]
        [HttpGet]
        public HttpResponseMessage ListarTurmas()
        {
            List<Turma> turmas = bll.ListarTurmas(connection);
            return Request.CreateResponse(HttpStatusCode.OK, turmas);
        }

        
    }
}