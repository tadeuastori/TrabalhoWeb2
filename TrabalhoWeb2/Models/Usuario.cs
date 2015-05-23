using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoWeb2.Models
{
    public class Usuario
    {
        [Display(Name="ID")]
        public int UsuarioId { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Nome é obrigatório!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Login é obrigatório!")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Senha é obrigatório!")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }



        public virtual ICollection<Agenda> FkUsuarioCriacaoAgenda { get; set; }
        public virtual ICollection<Participantes> FkUsuarioParticipante { get; set; }
    }
}