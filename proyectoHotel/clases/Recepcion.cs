namespace proyectoHotel.clases;

public class Recepcion
{
    private List<Factura> _facturas;

    private readonly double TasaSeguroHotelero = 0.25;
    private readonly double IVA = 0.19;

    public Recepcion()
    {
        _facturas = new List<Factura>();
    }

    public void CheckIn(Reserva reserva)
    {
        
    }
    
    public void CheckOut(Reserva reserva)
    {
        
    }

    public void PediHabitacion(Habitacion habitacion, Persona persona)
    {
        
    }

    public Factura Facturar(Reserva reserva)
    {
        return new Factura();
    }

    public void ManejarHabitacionLimpia(int idHabitacion)
    {
        
    }
    
    public void ManejarHabitacionOcupada(int idHabitacion)
    {
        
    }
    
    public void ManejarFacturaExitosa(int idFactura)
    {
        
    }
    
    
}