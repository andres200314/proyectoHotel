namespace proyectoHotel.clases;

public class Hotel
{
    private string _nombre;
    private string _direccion;
    private Oficina _oficina;
    private Recepcion _recepcion;
    private List<Habitacion> _habitaciones;
    private List<Persona> _personas;

    public Hotel(string nombre, string direccion, Oficina oficina, Recepcion recepcion)
    {
        _nombre = nombre;
        _direccion = direccion;
        _oficina = oficina;
        _recepcion = recepcion;
        _habitaciones = new List<Habitacion>();
        _personas = new List<Persona>();
    }
}

