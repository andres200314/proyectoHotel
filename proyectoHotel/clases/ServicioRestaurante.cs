namespace proyectoHotel.clases;

public class ServicioRestaurante
{
    private readonly Dictionary<string, double> _menu = new()
    {
        { "desayuno", 15000 },
        { "almuerzo", 25000 },
        { "cena", 20000 }
    };

    private double _servicioHabitacion = 5_000;

    public void PedirComida(byte cantidadPlatos, bool servicioHabitacion)
    {
        
    }
}