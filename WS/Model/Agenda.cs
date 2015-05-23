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
    [Table("Agenda")]
    public class Agenda
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int AgendaId { get; set; }

        [DataMember]
        [StringLength(50)]
        [Required(ErrorMessage = "Título é obrigatório!")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [DataMember]
        [StringLength(250)]
        [Required(ErrorMessage = "Descrição é obrigatório!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Usuário de Criação é obrigatório!")]
        [Display(Name = "Usuário de Criação")]
        public int UsuarioId { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Data do Compromisso é obrigatório!")]
        [Display(Name = "Data do Compromisso")]
        public DateTime DataCompromisso { get; set; }



        public virtual ICollection<Participantes> FkAgendaParticipante { get; set; }

        //[ForeignKey("UsuarioId")]
        //public virtual Usuario FkAgendaUsuario { get; set; }
    }
}