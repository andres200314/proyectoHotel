namespace proyectoHotel.clases;

public class Reserva
{
    private int id;
    private Habitacion habitacion;
    private Persona reservante;
    private DateTime fechaInicio;
    private DateTime fechaFin;
    private Estado estado = Estado.hecha;

    public enum Estado
    {
        hecha,
        confirmada,
        cancelada
    }

    public Reserva()
    {
        
    }
    public Reserva(Habitacion habitacion, Persona reservante, DateTime fechaInicio, DateTime fechaFin)
    {
        this.habitacion = habitacion;
        this.reservante = reservante;
        this.fechaInicio = fechaInicio;
        this.fechaFin = fechaFin;
    }

    
}