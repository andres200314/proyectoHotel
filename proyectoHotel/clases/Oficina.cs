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
        reserva.Estado = Reserva.TipoEstado.cancelada;

        switch (tipoCancelacion)
        {
            case TipoCancelacion.Cliente:
                ManejarCancelacionCliente(reserva.Id, "Cancelación solicitada por el cliente", tipoCancelacion);
                break;
            case TipoCancelacion.Hotel:
                ManejarCancelacionHotel(reserva.Id, "Realizada por el hotel", tipoCancelacion);
                break;
        }
    }


    public void ManejarCancelacionCliente(int idReserva, string motivo, TipoCancelacion tipoCancelacion)
    {
        _publisherCancelacion.Informar_Cancelacion(idReserva, motivo, tipoCancelacion);
    }

    public void ManejarCancelacionHotel(int idReserva, string motivo, TipoCancelacion tipoCancelacion)
    {
        _publisherCancelacion.Informar_Cancelacion(idReserva, motivo, tipoCancelacion);
    }
    
}