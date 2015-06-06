using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoWeb2.Controllers
{
    public class AgendaController : Controller
    {
        //
        // GET: /Agenda/

        public ActionResult ExibirCompromisso()//ver quando usar
        {
            //Possívelmente este será completamente substituído pela tela inicial que contem os menus!
            return View();
        }

        public ActionResult BoasVindas()//Tela Inicial com os menus
        {

            return View();
        }

        public ActionResult CadastrarCompromisso()//Tela para inserir os compromissos
        {
            return View();
        }

        public ActionResult ListarCompromissos()//Tela para exibir todos os compromisso cadastrados e permitir os compartilhamentos
        {
            return View();
        }


        public ActionResult NovoCompromisso()
        {
            return View();
        }

        public ActionResult EditarCompromisso()
        {
            return View();
        }

        [HttpGet]
        public JsonResult 
            Compromissos(int qtd)
        {
            WSAula.Service1Client ws = new WSAula.Service1Client();

            List<WSAula.Agenda> agenda = new List<WSAula.Agenda>();

            agenda = ws.lstCompromissos(MvcApplication.UsuarioID, 5).ToList();
            JsonResult js = new JsonResult() { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = agenda };
            return js;
        }

        [HttpGet]
        public JsonResult retornaParticipantes(int evento)
        {
            WSAula.Service1Client ws = new WSAula.Service1Client();

            List<WSAula.Participantes> participantes = new List<WSAula.Participantes>();
            List<WSAula.Usuario> usuario = new List<WSAula.Usuario>();

            participantes = ws.lstParticipantesCompromisso(evento).ToList();
            usuario = ws.lstUsuarioParticipantes(participantes).ToList();
            JsonResult js = new JsonResult() { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = usuario };
            return js;
        }


        [HttpPost]
        public ActionResult SalvarCompromisso(WSAula.Agenda model)
        {
            WSAula.Service1Client ws = new WSAula.Service1Client();

            if (ModelState.IsValid && ws.adicionaAgenda(model))
            {
               ViewBag.Msg = "Compromisso adicionado com sucesso";
               return View("BoasVindas");
            }
            else
            {
                ViewBag.MsgErro = "Usuario não foi adicionado";
                return View("CadastrarCompromissos");
            }
        }

    }
}
