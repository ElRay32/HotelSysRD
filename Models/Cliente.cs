using System.ComponentModel.DataAnnotations;

namespace HotelSysRD.Models
{
    // Representa un cliente registrado en el sistema del hotel
    public class Cliente
    {
        // Identificador único del cliente
        public int Id { get; set; }

        // Nombre del cliente
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        // Apellido del cliente
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres")]
        public string Apellido { get; set; } = string.Empty;

        // Correo electrónico del cliente
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido")]
        public string Email { get; set; } = string.Empty;

        // Teléfono del cliente
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "Debe ingresar un teléfono válido")]
        public string Telefono { get; set; } = string.Empty;

        // Documento de identidad del cliente
        [Required(ErrorMessage = "El documento es obligatorio")]
        [Display(Name = "Documento de Identidad")]
        public string DocumentoIdentidad { get; set; } = string.Empty;
    }
}