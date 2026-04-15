using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSysRD.Models
{
    // Representa una reservación realizada por un cliente para una habitación
    public class Reservacion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha y hora de entrada es obligatoria")]
        [Display(Name = "Fecha y Hora de Entrada")]
        public DateTime FechaEntrada { get; set; }

        [Required(ErrorMessage = "La fecha y hora de salida es obligatoria")]
        [Display(Name = "Fecha y Hora de Salida")]
        public DateTime FechaSalida { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public string Estado { get; set; } = "Activa";

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        [Display(Name = "Habitación")]
        public int HabitacionId { get; set; }

        [ForeignKey("HabitacionId")]
        public Habitacion? Habitacion { get; set; }
    }
}