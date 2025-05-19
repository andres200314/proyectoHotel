namespace proyectoHotel.publishers;

public class PublisherCambioEstadoHabitacion
{
    public delegate void DelegadoEstado(int idHabitacion);
    public event DelegadoEstado? EventoEstado;

    public void Informar_HabitacionLimpia(int idHabitacion)
    {
        EventoEstado?.Invoke(idHabitacion);
    }

    public void Informar_HabitacionOcupada(int idHabitacion)
    {
        EventoEstado?.Invoke(idHabitacion);
    }
}