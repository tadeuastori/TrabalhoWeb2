using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoWeb2.Models
{
    public class Agenda
    {
        [Display(Name = "ID")]
        public int AgendaId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Título é obrigatório!")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Descrição é obrigatório!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Usuário de Criação é obrigatório!")]
        [Display(Name = "Usuário de Criação")]
        public int UsuarioCriacaoId { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Data do Compromisso é obrigatório!")]
        [Display(Name = "Data do Compromisso")]
        public DateTime DataCompromisso { get; set; }



        public virtual ICollection<Participantes> FkAgendaParticipante { get; set; }


        [ForeignKey("UsuarioCriacaoId")]
        public virtual Usuario FkAgendaUsuarioCriacao { get; set; }
    }
}