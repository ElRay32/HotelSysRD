namespace HotelSysRD.ViewModels
{
    // Modelo que representa los datos resumidos del dashboard principal
    public class DashboardViewModel
    {
        public int TotalHabitaciones { get; set; }
        public int TotalClientes { get; set; }
        public int TotalReservaciones { get; set; }
        public int HabitacionesDisponibles { get; set; }
        public int HabitacionesOcupadas { get; set; }
        public int HabitacionesMantenimiento { get; set; }
    }
}