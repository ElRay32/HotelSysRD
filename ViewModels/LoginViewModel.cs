using System.ComponentModel.DataAnnotations;

namespace HotelSysRD.ViewModels
{
    // Modelo utilizado para capturar los datos del formulario de inicio de sesión
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; } = string.Empty;
    }
}