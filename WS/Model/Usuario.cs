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
    [Table("Usuario")]
    public class Usuario
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name="ID")]
        public int UsuarioId { get; set; }

        [DataMember]
        [StringLength(150)]
        [Required(ErrorMessage = "Nome é obrigatório!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [DataMember]
        [StringLength(50)]
        [Required(ErrorMessage = "Login é obrigatório!")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [DataMember]
        [StringLength(50)]
        [Required(ErrorMessage = "Senha é obrigatório!")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }



        //public virtual ICollection<Agenda> FkUsuarioCriacaoAgenda { get; set; }
        public virtual ICollection<Participantes> FkUsuarioParticipante { get; set; }
    }
}