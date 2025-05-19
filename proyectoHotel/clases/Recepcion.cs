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
    }

    public void CheckIn(Reserva reserva)
    {
        if (!reserva.Habitacion.Ocupada)
        {
            reserva.Habitacion.Ocupada = true;
            _publisherEstado.Informar_HabitacionOcupada(reserva.Habitacion.Numero);
        }
        
    }
    
    public Factura CheckOut(Reserva reserva)
    {
        // Al hacer check-out también puede cambiar el estado
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

    public void PediHabitacion(Habitacion habitacion, Persona persona)
    {
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
        ManejarFacturaExitosa(factura);

        return factura;
    }

    public void ManejarHabitacionLimpia(Habitacion habitacion)
    {
        _publisherEstado.Informar_HabitacionLimpia(habitacion.Numero);
    }
    
    public void ManejarHabitacionOcupada(Habitacion habitacion)
    {
        _publisherEstado.Informar_HabitacionOcupada(habitacion.Numero);
    }
     
    public void ManejarFacturaExitosa(Factura factura)
    {
        _publisherFactura.InformarFacturaExitosa(factura.Id);
    }
}