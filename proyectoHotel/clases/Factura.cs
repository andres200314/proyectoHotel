namespace proyectoHotel.clases;

public class Factura
{
    private int _id;
    private Reserva _reserva;
    private double _total = 0;

    


    public Factura(Reserva reserva)
    {
        _reserva = reserva;
    }
    public int Id { get => _id; }
    
    public double Total
    {
        get => _total;
    }

    public double CalcularTotal()
    {
        _total = 0;

        // Calcular número de noches
        TimeSpan duracion = _reserva.FechaFin - _reserva.FechaInicio;
        int noches = duracion.Days;

        // Validar que haya al menos una noche
        if (noches <= 0)
        {
            Console.WriteLine("Error: la reserva debe tener al menos una noche.");
            return 0;
        }

        // Agregar costo de habitación
        _total += noches * _reserva.Habitacion.CostoNoche;

        // Agregar consumos (por ejemplo, minibar)
        foreach (var consumo in _reserva.Habitacion.Consumos)
        {
            _total += consumo.Item2;
        }

        return _total;
    }

}