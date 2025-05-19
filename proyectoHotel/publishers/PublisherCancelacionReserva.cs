using proyectoHotel.clases;

public class PublisherCancelacionReserva
{
    public delegate void DelegadoCancelacion(int idReserva, string motivo, Oficina.TipoCancelacion tipo);
    public event DelegadoCancelacion? EventoCancelacion;

    public void Informar_Cancelacion(int idReserva, string motivo, Oficina.TipoCancelacion tipo)
    {
        EventoCancelacion?.Invoke(idReserva, motivo, tipo);
    }
}