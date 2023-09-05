using System.ComponentModel.DataAnnotations;

namespace CrudNet7.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Phone { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string MobilePhone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Email { get; set; }

        public DateTime DateCreate { get; set; }
    }
}
