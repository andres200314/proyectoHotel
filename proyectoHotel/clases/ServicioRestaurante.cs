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
    
    private readonly string _mensaje = "Restaurante";


    public (string, double) PedirComida(string platillo, byte cantidad, bool servicioHabitacion)
    {
        if (!_menu.ContainsKey(platillo))
            throw new ArgumentException("Platillo no existe");

        double precioBase = _menu[platillo];
        double precioTotal = precioBase * cantidad;
        if (servicioHabitacion)
            precioTotal += _servicioHabitacion;

        return (_mensaje, precioTotal);
    }
}