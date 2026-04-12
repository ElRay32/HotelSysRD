using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSysRD.Models
{
    // Representa una reservación realizada por un cliente para una habitación
    public class Reservacion
    {
        // Identificador único de la reservación
        public int Id { get; set; }

        // Fecha de entrada del cliente
        [Required(ErrorMessage = "La fecha de entrada es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Entrada")]
        public DateTime FechaEntrada { get; set; }

        // Fecha de salida del cliente
        [Required(ErrorMessage = "La fecha de salida es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Salida")]
        public DateTime FechaSalida { get; set; }

        // Estado de la reservación
        [Required(ErrorMessage = "El estado es obligatorio")]
        public string Estado { get; set; } = "Activa";

        // Clave foránea del cliente
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        // Relación con la entidad Cliente
        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        // Clave foránea de la habitación
        [Display(Name = "Habitación")]
        public int HabitacionId { get; set; }

        // Relación con la entidad Habitacion
        [ForeignKey("HabitacionId")]
        public Habitacion? Habitacion { get; set; }
    }
}