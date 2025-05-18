namespace proyectoHotel.clases
{
    public class Oficina
    {
        private List<Reserva> _reservas;

        public Oficina()
        {
            _reservas = new List<Reserva>();
        }

        public Reserva Reservar(Habitacion habitacion, Persona reservante, DateTime fechaInicio, DateTime fechaFin)
        {
            return new Reserva();
        }

        public void CancelarReserva(Reserva reserva)
        {
            
        }

        public void ManejarCancelacionCliente(int idReserva, string motivo)
        {
            
        }
        
        public void ManejarCancelacionHotel(int idReserva, string motivo)
        {
            
        }
        
        
    }
}
