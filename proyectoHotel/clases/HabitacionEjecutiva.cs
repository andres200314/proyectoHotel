using proyectoHotel.interfaces;
using proyectoHotel.publishers;

namespace proyectoHotel.clases;

public class HabitacionEjecutiva : Habitacion, IMiniBar
{
    private TipoCamaEjecutiva _tipoCama;
    private MiniBar _miniBar;

    public enum TipoCamaEjecutiva { Queen, DosSemiDobles }

    private readonly Dictionary<string, byte> _itemsMiniBar = new()
    {
        { "botellaVino", 0 },
        { "botellasLicor", 4 },
        { "kitAseo", 1 },
        { "gaseosas", 2 },
        { "batas", 0 }
    };

    public static readonly Pisos Piso = Pisos.P5;
    private static readonly double _CostoNoche = 350_000;
    public static readonly byte MaxHabitaciones = 10;

    public HabitacionEjecutiva(int numero, Pisos piso, TipoHabitacion tipo, TipoCamaEjecutiva tipoCama, PublisherConsumoMiniBar publisher)
        : base(numero, piso, tipo, _CostoNoche)
    {
        _tipoCama = tipoCama;
        _miniBar = new MiniBar(new Dictionary<string, byte>(_itemsMiniBar), publisher);
    }

    public static double CostoNoche => _CostoNoche;

    public TipoCamaEjecutiva TipoCama
    {
        get => _tipoCama;
        set => _tipoCama = value;
    }

    public void LlenarMiniBar()
    {
        try
        {
            _miniBar.Productos.Clear();
            foreach (var item in _itemsMiniBar)
            {
                _miniBar.Productos[item.Key] = item.Value;
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al llenar el minibar de la habitación {Numero}: {ex.Message}", ex);
        }
    }

    public void ConsumirMiniBar(string item, byte cantidad)
    {
        try
        {
            _miniBar.Consumir(item, cantidad);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al consumir del minibar en la habitación {Numero}: {ex.Message}", ex);
        }
    }
}