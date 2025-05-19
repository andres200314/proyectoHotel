namespace proyectoHotel.publishers;

public class PublisherCambioEstadoHabitacion
{
    public delegate void DelegadoEstado(int idHabitacion);
    public event DelegadoEstado? EventoEstado;

    public void Informar_HabitacionLimpia(int numeroHabitacion)
    {
        EventoEstado?.Invoke(numeroHabitacion);
    }

    public void Informar_HabitacionOcupada(int numeroHabitacion)
    {
        EventoEstado?.Invoke(numeroHabitacion);
    }
}