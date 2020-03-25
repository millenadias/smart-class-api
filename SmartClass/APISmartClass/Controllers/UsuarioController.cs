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
        string connection = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        [Route("usuario/validarAcesso")]
        [HttpGet]
        public HttpResponseMessage ValidarAcesso(String pDsLogin, String pDsSenha)
        {
            UsuarioBLL bll = new UsuarioBLL();
            bool acesso = bll.ValidarAcesso(pDsLogin, pDsSenha, connection);
            return Request.CreateResponse(HttpStatusCode.OK, acesso);
        }

        [Route("usuario/Get")]
        [HttpGet]
        public HttpResponseMessage Get(int pCdUsuario)
        {
            UsuarioBLL bll = new UsuarioBLL();
            Usuario user = bll.Get(pCdUsuario, connection);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Route("usuario/Cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar(Usuario user)
        {
            UsuarioBLL bll = new UsuarioBLL();
            bll.Cadastrar(user, connection);
            return Request.CreateResponse(HttpStatusCode.OK, "Usuário Cadastrado");
        }

        [Route("usuario/GetAlunosTurma")]
        [HttpGet]
        public HttpResponseMessage GetAlunosTurma(int pCdTurma)
        {
            UsuarioBLL bll = new UsuarioBLL();
            List<Usuario> lstAlunos = bll.GetAlunosTurma(pCdTurma, connection);
            return Request.CreateResponse(HttpStatusCode.OK, lstAlunos);
        }

        [Route("usuario/Alterar")]
        [HttpPut]
        public HttpResponseMessage Alterar(Usuario user)
        {
            UsuarioBLL bll = new UsuarioBLL();
            bll.Alterar(user, connection);
            return Request.CreateResponse(HttpStatusCode.OK, "Usuário alterado");
        }
    }
}