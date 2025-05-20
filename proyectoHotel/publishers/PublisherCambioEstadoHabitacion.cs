using proyectoHotel.clases;

namespace proyectoHotel.publishers;

public class PublisherCambioEstadoHabitacion
{
    public delegate void DelegadoEstado(Habitacion habitacion);
    public event DelegadoEstado? EventoEstado;

    public void Informar_HabitacionLimpia(Habitacion habitacion)
    {
        EventoEstado?.Invoke(habitacion);
    }

    public void Informar_HabitacionOcupada(Habitacion habitacion)
    {
        EventoEstado?.Invoke(habitacion);
    }
}