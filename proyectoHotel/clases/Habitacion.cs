namespace proyectoHotel.clases;

public abstract class Habitacion
{
    private uint _numero;
    private Piso _piso;
    private Tipo _tipo;
    private double _costoNoche;
    private bool _ocupada;
    private Dictionary<string, double> _consumos;

    public enum Piso
    {
       P1,P2,P3,P4,P5,P6
    }
    
    public enum Tipo
    {
        Sencilla, Ejecutiva, Suit
    }
    
    protected Habitacion(uint numero, Piso piso, Tipo tipo, double costoNoche)
    {
        _numero = numero;
        _piso = piso;
        _tipo = tipo;
        _costoNoche = costoNoche;
        _ocupada = false;
        _consumos = new Dictionary<string, double>();
    }

    
}