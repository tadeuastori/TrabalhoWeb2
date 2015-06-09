using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TrabalhoWeb2.Models;

namespace WS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool verificaLogin(string usuario, string senha);


        [OperationContract]
        bool adicionaUsuario(Usuario usuario);

        [OperationContract]
        bool adicionaAgenda(Agenda agenda);

        [OperationContract]
        bool adicionaParticipante(Participantes participante);


        [OperationContract]
        List<Agenda> lstCompromissos(int IdUsuario, int qtd);

        [OperationContract]
        List<Usuario> lstUsuario(int idUsuario);

        [OperationContract]
        List<Participantes> lstParticipantesCompromisso(int idAgenda);

        [OperationContract]
        List<Usuario> lstUsuarioParticipantes(List<Participantes> lstPart);


        [OperationContract]
        Agenda retornaCompromisso(int idAgenda);

        [OperationContract]
        Usuario retornaUsuarioPorID(int idUsuario);

        [OperationContract]
        Usuario retornaUsuarioPorLOGIN(string login);

        [OperationContract]
        bool verificaParticipante(int IdUsuario, int IdAgenda);

        [OperationContract]
        bool excluirParticipantes(int IdUsuario, int IdAgenda);
    }
}
