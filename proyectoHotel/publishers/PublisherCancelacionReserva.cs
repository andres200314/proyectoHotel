namespace proyectoHotel.publishers;

public class PublisherCancelacionReserva
{
    public delegate void DelegadoCancelacion(int idReserva, string motivo);
    public event DelegadoCancelacion? EventoCancelacion;

    public void Informar_CancelacionPorCliente(int idReserva, string motivo)
    {
        EventoCancelacion?.Invoke(idReserva, motivo);
    }

    public void Informar_CancelacionPorHotel(int idReserva, string motivo)
    {
        EventoCancelacion?.Invoke(idReserva, motivo);
    }
}