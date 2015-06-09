using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoWeb2.Controllers
{
    public class AgendaController : BaseController
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

        public ActionResult AssociarParticipante(string evento)
        {
            WSAula.Service1Client ws = new WSAula.Service1Client();
            WSAula.Agenda agenda = new WSAula.Agenda();

            agenda = ws.retornaCompromisso(Convert.ToInt32(evento));

            return View(agenda);
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

            agenda = ws.lstCompromissos(MvcApplication.UsuarioID, qtd).ToList();
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

            model.UsuarioId = MvcApplication.UsuarioID;

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

        [HttpGet]
        public JsonResult listarUsuario()
        {
            WSAula.Service1Client ws = new WSAula.Service1Client();
            List<WSAula.Usuario> usuario = new List<WSAula.Usuario>();

            usuario = ws.lstUsuario(MvcApplication.UsuarioID).ToList();

            JsonResult js = new JsonResult() { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = usuario };
            return js;
        }

        [HttpPost]
        public ActionResult adicionarParticipante(String IdUsuario, String IdAgenda, String IdNovoUsuario)
        {
            WSAula.Service1Client ws = new WSAula.Service1Client();

            //ADICIONAR PARTICIPANTE
            if (!ws.verificaParticipante(Convert.ToInt32(IdNovoUsuario), Convert.ToInt32(IdAgenda)))
            {
                WSAula.Participantes participante = new WSAula.Participantes();

                participante.UsuarioID = Convert.ToInt32(IdNovoUsuario);
                participante.AgendaId = Convert.ToInt32(IdAgenda);

                ws.adicionaParticipante(participante);
            }

            return View("AssociarParticipante");
        }

        [HttpPost]
        public ActionResult removerParticipante(String IdUsuario, String IdAgenda, String IdNovoUsuario)
        {
            WSAula.Service1Client ws = new WSAula.Service1Client();

            ws.excluirParticipantes(Convert.ToInt32(IdNovoUsuario), Convert.ToInt32(IdAgenda));

            return View("AssociarParticipante");
        }


    }
}
