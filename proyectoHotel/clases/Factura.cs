namespace proyectoHotel.clases;

public class Factura
{
    private int _id;
    private Reserva _reserva;
    private double _total;


    public Factura()
    {
        
    }
    public Factura(Reserva reserva, double total)
    {
        _reserva = reserva;
        _total = total;
    }
}