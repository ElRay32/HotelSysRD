using System.ComponentModel.DataAnnotations;

namespace HotelSysRD.Models
{
    // Representa una habitación dentro del hotel
    public class Habitacion
    {
        // Identificador único de la habitación
        public int Id { get; set; }

        // Número de la habitación (Ej: 101, 202)
        [Required(ErrorMessage = "El número es obligatorio")]
        public string Numero { get; set; } = string.Empty;

        // Tipo de habitación (Simple, Doble, Suite)
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Tipo { get; set; } = string.Empty;

        // Precio por noche
        [Range(1, 100000)]
        public decimal PrecioPorNoche { get; set; }

        // Estado actual (Disponible, Ocupada, Mantenimiento)
        public string Estado { get; set; } = "Disponible";

        // Cantidad de personas que soporta
        [Range(1, 10)]
        public int Capacidad { get; set; }
    }
}