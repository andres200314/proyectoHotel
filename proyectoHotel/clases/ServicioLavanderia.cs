namespace proyectoHotel.clases;

public class ServicioLavanderia
{
    
    private readonly double _valorPorPrenda = 12_000;
    private readonly double _valorPorPlanchado = 9_000;

    private readonly string _mensaje = "Lavanderia";
    public (string, double) PedirServicio(byte cantidadPrendas, bool planchado)
    {
        double total = 0;
        total += _valorPorPrenda*cantidadPrendas;
        if (planchado) total += _valorPorPlanchado;
        return (_mensaje, total);
    }
}