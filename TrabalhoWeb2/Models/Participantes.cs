using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoWeb2.Models
{
    public class Participantes
    {
        public int ParticipantesID { get; set; }
        public int UsuarioID { get; set; }
        public int AgendaId { get; set; }


        [ForeignKey("UsuarioID")]
        public virtual Usuario FkParticipanteUsuario { get; set; }

        [ForeignKey("AgendaId")]
        public virtual Agenda FkParticipanteAgenda { get; set; }
    }
}