using proyectoHotel.publishers;

namespace proyectoHotel.clases;

public class Recepcion
{
    private List<Factura> _facturas;

    private readonly double TasaSeguroHotelero = 0.25;
    private readonly double IVA = 0.19;

    private PublisherCambioEstadoHabitacion _publisherEstado;
    private PublisherFacturacionExitosa _publisherFactura;

    public Recepcion(PublisherCambioEstadoHabitacion publisherEstado, PublisherFacturacionExitosa publisherFactura)
    {
        _facturas = new List<Factura>();
        _publisherEstado = publisherEstado;
        _publisherFactura = publisherFactura;
        _publisherFactura.EventoFactura += ManejarFacturaExitosa;
        _publisherEstado.EventoEstado += OnCambioEstadoHabitacion;
    }

    public void CheckIn(Reserva reserva)
    {
        if (reserva.Estado == Reserva.TipoEstado.cancelada)
        {
            throw new InvalidOperationException("No se puede hacer Check-In: la reserva está cancelada.");
        }
        
        if (!reserva.Habitacion.Ocupada)
        {
            reserva.Habitacion.Ocupada = true;
            _publisherEstado.Informar_HabitacionOcupada(reserva.Habitacion.Numero);
        }
        
    }
    
    public Factura CheckOut(Reserva reserva)
    {
        if (reserva.Estado == Reserva.TipoEstado.cancelada)
        {
            throw new InvalidOperationException("No se puede hacer Check-In: la reserva está cancelada.");
        }
        
        if (reserva.Habitacion.Ocupada)
        {
            reserva.Habitacion.Ocupada = false;
            _publisherEstado.Informar_HabitacionLimpia(reserva.Habitacion.Numero);
            
            return Facturar(reserva);
        }
        else
        {
            throw new InvalidOperationException($"No se puede hacer Check-Out: la habitación {reserva.Habitacion.Numero} ya está desocupada.");
        }
    }

    public void PedirHabitacion(Habitacion habitacion,List<Reserva> _reservas, Persona persona)
    {
        if (persona.GetType() != typeof(Cliente))
        {
            throw new InvalidOperationException($"Los huespedes no pueden pedir habitaciones sin una reserva");
        }
        // Verificar si la habitación está en alguna reserva activa
        bool estaEnReservaActiva = _reservas.Any(r => r.Habitacion == habitacion && r.Estado != Reserva.TipoEstado.cancelada);

        if (estaEnReservaActiva)
        {
            throw new InvalidOperationException($"No se puede pedir la habitación {habitacion.Numero} porque está en una reserva activa.");
        }

        if (!habitacion.Ocupada)
        {
            habitacion.Ocupada = true;
            _publisherEstado.Informar_HabitacionOcupada(habitacion.Numero);
        }
    }


    public Factura Facturar(Reserva reserva)
    {
        var factura = new Factura(reserva);
        _facturas.Add(factura);
        ManejarFacturaExitosa(factura.Id);

        return factura;
    }

    private void OnCambioEstadoHabitacion(int numeroHabitacion)
    {
        Console.WriteLine($"[Recepcion] La habitación {numeroHabitacion} cambió de estado.");
    }
    
    public void ManejarHabitacionLimpia(Habitacion habitacion)
    {
        _publisherEstado.Informar_HabitacionLimpia(habitacion.Numero);
    }
    
    public void ManejarHabitacionOcupada(Habitacion habitacion)
    {
        _publisherEstado.Informar_HabitacionOcupada(habitacion.Numero);
    }
     
    public void ManejarFacturaExitosa(int facturaId)
    {
        Console.WriteLine($"[Recepción] Se ha manejado exitosamente la factura con ID: {facturaId}");
    }

}