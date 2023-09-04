using System.ComponentModel.DataAnnotations;

namespace CrudNet7.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string MobilePhone { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Email { get; set; }

        public DateTime DateCreate { get; set; }
    }
}
