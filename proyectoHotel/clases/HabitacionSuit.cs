using proyectoHotel.interfaces;
using proyectoHotel.publishers;

namespace proyectoHotel.clases;

public class HabitacionSuit: Habitacion, IMiniBar
{
    private TipoCamaSuit _tipoCama;
    private MiniBar _miniBar;
    
    public enum TipoCamaSuit { King, QueenYSemiDoble }
    private Dictionary<string, byte> itemsMiniBar  = new()
    {
        { "botellaVino", 1 },
        { "botellasLicor", 4 },
        { "kitAseo", 3 },
        { "gaseosas", 4 },
        { "batas", 2 }
    };
    
    public static readonly Pisos Piso = Pisos.P6;
    public static readonly byte MaxHabitaciones = 5;
    private static readonly double _CostoNoche = 500_000;
    

    public HabitacionSuit(int numero, Pisos piso, TipoHabitacion tipo, TipoCamaSuit tipoCama, PublisherConsumoMiniBar publisher) : base(numero, piso, tipo, _CostoNoche)
    {
        _tipoCama = tipoCama;
        _miniBar = new MiniBar(new Dictionary<string, byte>(itemsMiniBar), publisher);
    }
    
    public static double CostoNoche => _CostoNoche;

    public TipoCamaSuit TipoCama
    {
        get => _tipoCama;
        set => _tipoCama = value;
    }

    public void LlenarMiniBar()
    {
        _miniBar.Productos.Clear();
        foreach (var item in itemsMiniBar)
        {
            _miniBar.Productos[item.Key] = item.Value;
        }
    }

    public void ConsumirMiniBar(string item, byte cantidad)
    {
        var consumo = _miniBar.Consumir(item, cantidad);
        this.Consumos.Add(consumo);
    }
    


}