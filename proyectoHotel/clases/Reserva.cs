namespace proyectoHotel.clases;

public class Reserva
{
    private int _id;

    

    private Habitacion _habitacion;

    

    private Persona _reservante;
    private DateTime _fechaInicio;
    private DateTime _fechaFin;
    private TipoEstado _estado = TipoEstado.hecha;

    public enum TipoEstado { hecha, confirmada, cancelada }
    
    public int Id { get => _id; }
    public Habitacion Habitacion
    {
        get => _habitacion;
    }
    public TipoEstado Estado
    {
        get => _estado;
        set => _estado = value;
    }

    public DateTime FechaInicio
    {
        get => _fechaInicio;
    }

    public DateTime FechaFin
    {
        get => _fechaFin;
    }


    public Reserva()
    {
        
    }

    public Reserva(Habitacion habitacion, Persona reservante, DateTime fechaInicio, DateTime fechaFin)
    {
        _habitacion = habitacion;
        _reservante = reservante;
        _fechaInicio = fechaInicio;
        _fechaFin = fechaFin;
    }
}