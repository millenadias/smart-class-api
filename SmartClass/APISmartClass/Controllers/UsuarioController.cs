using SmartClass.BLL;
using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APISmartClass.Controllers
{
    [EnableCors("*", "*", "GET,POST,PUT,DELETE,OPTIONS")]
    [Serializable]
    public class UsuarioController : ApiController
    {
        string connection = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        [Route("usuario/validarAcesso")]
        [HttpGet]
        public HttpResponseMessage ValidarAcesso(String pDsLogin, String pDsSenha)
            {
            try
            {
                UsuarioBLL bll = new UsuarioBLL();
                bool acesso = bll.ValidarAcesso(pDsLogin, pDsSenha, connection);
                return Request.CreateResponse(HttpStatusCode.OK, acesso);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("usuario/Get")]
        [HttpGet]
        public HttpResponseMessage Get(int pCdUsuario)
        {
            try
            {
                UsuarioBLL bll = new UsuarioBLL();
                Usuario user = bll.Get(pCdUsuario, connection);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("usuario/Cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar(Usuario user)
        {
            try
            {
                UsuarioBLL bll = new UsuarioBLL();
                bll.Cadastrar(user, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "Usuário Cadastrado");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("usuario/GetAlunosTurma")]
        [HttpGet]
        public HttpResponseMessage GetAlunosTurma(int pCdTurma)
        {
            try
            {
                UsuarioBLL bll = new UsuarioBLL();
                List<Usuario> lstAlunos = bll.GetAlunosTurma(pCdTurma, connection);
                return Request.CreateResponse(HttpStatusCode.OK, lstAlunos);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("usuario/Alterar")]
        [HttpPut]
        public HttpResponseMessage Alterar(Usuario user)
        {
            try
            {
                UsuarioBLL bll = new UsuarioBLL();
                bll.Alterar(user, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "Usuário alterado");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("usuario/GetPorLoginSenha")]
        [HttpGet]
        public HttpResponseMessage GetPorLoginSenha(String pDsLogin, String pDsSenha)
        {
            try
            {
                UsuarioBLL bll = new UsuarioBLL();
                Usuario user = bll.GetPorLoginSenha(pDsLogin, pDsSenha, connection);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}