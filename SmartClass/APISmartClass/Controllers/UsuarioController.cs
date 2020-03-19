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
    public class UsuarioController: ApiController
    {
        [Route("usuario/validarAcesso")]
        [HttpGet]
        public HttpResponseMessage ValidarAcesso(String pDsLogin, String pDsSenha)
        {
            UsuarioBLL bll = new UsuarioBLL();
            bool acesso = bll.ValidarAcesso(pDsLogin, pDsSenha);
            return Request.CreateResponse(HttpStatusCode.OK, acesso);
        }

        [Route("usuario/Get")]
        [HttpGet]
        public HttpResponseMessage Get(int pCdUsuario)
        {
            UsuarioBLL bll = new UsuarioBLL();
            Usuario user = bll.Get(pCdUsuario);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Route("usuario/Cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar()
        {
            UsuarioBLL bll = new UsuarioBLL();
            bll.Cadastrar(new Usuario());
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("usuario/GetAlunosTurma")]
        [HttpGet]
        public HttpResponseMessage GetAlunosTurma(int pCdTurma)
        {
            UsuarioBLL bll = new UsuarioBLL();
            List<Usuario> lstAlunos = bll.GetAlunosTurma(pCdTurma);
            return Request.CreateResponse(HttpStatusCode.OK, lstAlunos);
        }

        [Route("usuario/Alterar")]
        [HttpPut]
        public HttpResponseMessage Alterar(Usuario dadosUser)
        {
           // UsuarioBLL bll = new UsuarioBLL();
           // List<Usuario> lstAlunos = bll.GetAlunosTurma(pCdTurma);
            return Request.CreateResponse(HttpStatusCode.OK, "Teste");
        }
    }
}