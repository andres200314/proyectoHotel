using proyectoHotel.publishers;
using proyectoHotel.excepciones;

namespace proyectoHotel.clases;

public class Hotel
{
    private string _nombre;
    private string _direccion;
    private Oficina _oficina;
    private Recepcion _recepcion;
    private List<Habitacion> _habitaciones;
    private List<Persona> _personas;

    private readonly PublisherConsumoMiniBar _publisherMiniBar = new();
    private readonly PublisherCambioEstadoHabitacion _publisherCambioEstado = new();
    private readonly PublisherCancelacionReserva _publisherCancelacion = new();
    private readonly PublisherFacturacionExitosa _publisherFacturacionExitosa = new();




    public Hotel(string nombre, string direccion)
    {
        _nombre = nombre;
        _direccion = direccion;
        _oficina = new Oficina(_publisherCancelacion);
        _recepcion = new Recepcion(_publisherCambioEstado, _publisherFacturacionExitosa);
        _habitaciones = new List<Habitacion>();
        _personas = new List<Persona>();

        try
        {
            InicializarSistema();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Error en inicialización del hotel]: {ex.Message}");
            throw; 
        }
    }

    public Oficina Oficina
    {
        get => _oficina;
    }

    public Recepcion Recepcion
    {
        get => _recepcion;
    }

    public List<Habitacion> Habitaciones
    {
        get => _habitaciones;
    }

    public List<Persona> Personas
    {
        get => _personas;
    }

    private void InicializarSistema()
    {
        try
        {
            _publisherMiniBar.EventoConsumo += RegistrarConsumo;
            CrearHabitacionesSencillas();
            CrearHabitacionesEjecutivas();
            CrearHabitacionesSuit();
        }
        catch (Exception ex)
        {
            throw new Exception("[Error al inicializar el sistema de eventos del minibar]", ex);
        }
    }

    private void RegistrarConsumo(string producto, byte cantidad)
    {
        try
        {
            Console.WriteLine($"[Hotel] Se registró el consumo de {cantidad} unidad(es) de '{producto}' desde el minibar.");
        }
        catch (Exception ex)
        {
            throw new Exception($"[Error al registrar consumo del minibar]: {ex.Message}", ex);
        }
    }

    private void CrearHabitacionesSencillas()
    {
        try
        {
            var tipo = Habitacion.Tipo.Sencilla;
            var tipoCama = HabitacionSencilla.TipoCama.Doble;

            for (int i = HabitacionSencilla.MinPiso; i <= HabitacionSencilla.MaxPiso; i++)
            {
                for (int j = 1; j <= 10; j++) 
                {
                    int numeroHabitacion = i * 100 + j;
                    string nombrePiso = $"P{i}";

                    if (Enum.TryParse<Habitacion.Piso>(nombrePiso, out var piso))
                    {
                        var habitacion = new HabitacionSencilla(numeroHabitacion, piso, tipo, tipoCama);
                        _habitaciones.Add(habitacion);
                    }
                    else
                    {
                        throw new PisoInvalidoException($"Piso inválido: '{nombrePiso}' no se reconoce como piso válido.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new HabitacionNoCreadaException($"Error al crear habitaciones sencillas: {ex.Message}");
        }
    }

    private void CrearHabitacionesEjecutivas()
    {
        try
        {
            int numero = 500;
            for (int i = 0; i < HabitacionEjecutiva.MaxHabitaciones; i++)
            {
                var habitacion = new HabitacionEjecutiva(
                    numero + i,
                    HabitacionEjecutiva.Piso,
                    Habitacion.Tipo.Ejecutiva,
                    HabitacionEjecutiva.TipoCama.Queen,
                    _publisherMiniBar
                );
                _habitaciones.Add(habitacion);
            }
        }
        catch (Exception ex)
        {
            throw new HabitacionNoCreadaException($"Error al crear habitaciones ejecutivas: {ex.Message}");
        }
    }

    private void CrearHabitacionesSuit()
    {
        try
        {
            int numero = 600;
            for (int i = 0; i < HabitacionSuit.MaxHabitaciones; i++)
            {
                var habitacion = new HabitacionSuit(
                    numero + i,
                    HabitacionSuit.Piso,
                    Habitacion.Tipo.Suit,
                    HabitacionSuit.TipoCama.King,
                    _publisherMiniBar
                );
                _habitaciones.Add(habitacion);
            }
        }
        catch (Exception ex)
        {
            throw new HabitacionNoCreadaException($"Error al crear habitaciones tipo Suit: {ex.Message}");
        }
    }
}
