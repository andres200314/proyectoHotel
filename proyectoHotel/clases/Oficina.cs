using proyectoHotel.clases;

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
        _publisherCancelacion.EventoCancelacion += ManejarCancelacionReserva;
    }

    public List<Reserva> Reservas => _reservas;

    public void Reservar(Habitacion habitacion, Persona reservante, DateTime fechaInicio, DateTime fechaFin)
    {
        var reserva = new Reserva(habitacion, reservante, fechaInicio, fechaFin);
        _reservas.Add(reserva);
    }

    public void CancelarReserva(Reserva reserva, TipoCancelacion tipoCancelacion)
    {
        reserva.Estado = Reserva.TipoEstado.cancelada;

        string motivo = tipoCancelacion switch
        {
            TipoCancelacion.Cliente => "Cancelación solicitada por el cliente",
            TipoCancelacion.Hotel => "Realizada por el hotel",
            _ => "Cancelación sin motivo"
        };

        _publisherCancelacion.Informar_Cancelacion(reserva.Id, motivo, tipoCancelacion);
    }
    
    private void ManejarCancelacionReserva(int idReserva, string motivo, TipoCancelacion tipo)
    {
        Console.WriteLine($"[Oficina] Cancelación recibida: Reserva ID {idReserva}, Motivo: {motivo}, Tipo: {tipo}");
    }
}