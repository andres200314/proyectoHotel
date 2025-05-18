namespace proyectoHotel.clases;

public abstract class Habitacion
{
    private uint _numero;
    private byte _piso;
    private double _costoNoche;
    private bool ocupada;

    protected Habitacion(uint numero, byte piso, double precio)
    {
        _numero = numero;
        _piso = piso;
        _costoNoche = precio;
        ocupada = false;
    }
    
    public void CalcularCosto()
    {
        
    }

    public void checkIn()
    {

    }

    public void checkOut()
    {
        
    }

}