using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoWeb2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NovoUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(string txtUsuario, string txtSenha)
        {
            WSAula.Service1Client ws = new WSAula.Service1Client();
            WSAula.Usuario usuario = new WSAula.Usuario();

            if (ws.verificaLogin(txtUsuario, txtSenha))
            {
                MvcApplication.UsuarioID = ws.retornaUsuarioPorLOGIN(txtUsuario).UsuarioId;

                return RedirectToAction("ExibirCompromisso", "Agenda");
            }
            else
            {
                ViewBag.MsgErro = "Usuário não existe";
                return View("Index");
            }
        }

        [HttpPost] 
        public ActionResult salvarUsuario(WSAula.Usuario model)
        {
            WSAula.Service1Client ws = new WSAula.Service1Client();


            if (ws.verificaLogin(model.Login, model.Senha))
            {
                ViewBag.Msg = "Usuario já existe";
            }
            else
            {
                if (ModelState.IsValid && ws.adicionaUsuario(model))
                {
                    ViewBag.Msg = "Usuario adicionado com sucesso";
                }
                else
                {
                    ViewBag.Msg = "Usuario não foi adicionado";
                }

            }

            ModelState.Clear();

            return View("NovoUsuario");
        }
    }
}
