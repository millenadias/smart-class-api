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
        TurmaBLL bll = new TurmaBLL();

        [Route("turma/Inserir")]
        [HttpPost]
        public HttpResponseMessage Inserir(Turma turma)
        {
            bll.Inserir(turma);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("turma/InserirAlunoTurma")]
        [HttpPost]
        public HttpResponseMessage InserirAlunoTurma(int pCdAluno, int pCdTurma)
        {
            bll.InserirAlunoTurma(pCdAluno, pCdTurma);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("turma/AlterarTurma")]
        [HttpPost]
        public HttpResponseMessage AlterarTurma(Turma turma)
        {
            bll.AlterarTurma(turma);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("turma/ListarTurmas")]
        [HttpPost]
        public HttpResponseMessage ListarTurmas()
        {;
            List<Turma> turmas = bll.ListarTurmas();
            return Request.CreateResponse(HttpStatusCode.OK, turmas);
        }

        [Route("turma/ListarAlunosTurma")]
        [HttpPost]
        public HttpResponseMessage ListarAlunosTurma(int pCdTurma)
        {
            List<Usuario> turmas = bll.ListarAlunosTurma(pCdTurma);
            return Request.CreateResponse(HttpStatusCode.OK, turmas);
        }
    }
}