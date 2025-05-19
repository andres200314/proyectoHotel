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
        // Aquí puedes usar el publisher si cambia el estado
        // _publisherEstado.Informar_HabitacionOcupada(reserva.habitacion.id);
    }
    
    public void CheckOut(Reserva reserva)
    {
        // Al hacer check-out también puede cambiar el estado
        // _publisherEstado.Informar_HabitacionLimpia(reserva.IdHabitacion);
    }

    public void PediHabitacion(Habitacion habitacion, Persona persona)
    {
        // Implementa la lógica necesaria
    }

    public Factura Facturar(Reserva reserva)
    {
        // Supongamos que genera una factura con ID incremental
        var factura = new Factura(); // Asume que le asignas un ID
        _facturas.Add(factura);
        // _publisherFactura.InformarFacturaExitosa(factura.Id); // Aquí informas del evento

        return factura;
    }

    public void ManejarHabitacionLimpia(Habitacion habitacion)
    {
        // _publisherEstado.Informar_HabitacionLimpia(habitacion.Id);
    }
    
    public void ManejarHabitacionOcupada(Habitacion habitacion)
    {
        // _publisherEstado.Informar_HabitacionOcupada(habitacion.Id);
    }
     
    public void ManejarFacturaExitosa(Factura factura)
    {
        // _publisherFactura.InformarFacturaExitosa(factura.Id);
    }
}