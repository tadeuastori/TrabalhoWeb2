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

        public ActionResult ExibirCompromisso()
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
        public JsonResult retornaCompromissos(int qtd)
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
    }


}
