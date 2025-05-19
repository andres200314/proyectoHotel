using proyectoHotel.publishers;

namespace proyectoHotel.clases;

public class Oficina
{
    private List<Reserva> _reservas;
    private PublisherCancelacionReserva _publisherCancelacion;
    
    public enum TipoCancelacion
    {
        Cliente,
        Hotel
    }


    public Oficina(PublisherCancelacionReserva publisherCancelacion)
    {
        _reservas = new List<Reserva>();
        _publisherCancelacion = publisherCancelacion;
    }

    public void Reservar(Habitacion habitacion, Persona reservante, DateTime fechaInicio, DateTime fechaFin)
    {
        var reserva = new Reserva(habitacion, reservante, fechaInicio, fechaFin);
        _reservas.Add(reserva);
    }

    public void CancelarReserva(Reserva reserva, TipoCancelacion tipoCancelacion)
    {
        // reserva.estado = Reserva.Estado.cancelada;
        // Podrías decidir si es por cliente u hotel. Por ahora ejemplo con cliente
        if (tipoCancelacion == TipoCancelacion.Cliente)
        {
            // _publisherCancelacion.Informar_CancelacionPorCliente(reserva.Id, "Cancelación solicitada por el cliente");
        }
        else if (tipoCancelacion == TipoCancelacion.Hotel)
        {
            // _publisherCancelacion.Informar_CancelacionPorHotel(reserva.Id, "Realizada por el hotel");
        }
        
    }

    public void ManejarCancelacionCliente(int idReserva, string motivo)
    {
        _publisherCancelacion.Informar_CancelacionPorCliente(idReserva, motivo);
    }

    public void ManejarCancelacionHotel(int idReserva, string motivo)
    {
        _publisherCancelacion.Informar_CancelacionPorHotel(idReserva, motivo);
    }
    
}