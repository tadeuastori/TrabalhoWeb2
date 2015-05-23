using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TrabalhoWeb2.Models
{
    [DataContract]
    [Table("Participante")]
    public class Participantes
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParticipantesID { get; set; }

        [DataMember]
        public int UsuarioID { get; set; }

        [DataMember]
        public int AgendaId { get; set; }


        [ForeignKey("UsuarioID")]
        public virtual Usuario FkParticipanteUsuario { get; set; }

        [ForeignKey("AgendaId")]
        public virtual Agenda FkParticipanteAgenda { get; set; }
    }
}