namespace proyectoHotel.excepciones;

public class PisoInvalidoException : Exception
{
    public PisoInvalidoException(string mensaje) : base(mensaje) { }
}

public class HabitacionNoCreadaException : Exception
{
    public HabitacionNoCreadaException(string mensaje) : base(mensaje) { }
}