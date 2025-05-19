namespace proyectoHotel.publishers;

public class PublisherFacturacionExitosa
{
    public delegate void DelegadoFactura(int idFactura);
    public event DelegadoFactura? EventoFactura;

    public void InformarFacturaExitosa(int idFactura)
    {
        EventoFactura?.Invoke(idFactura);
    }
}