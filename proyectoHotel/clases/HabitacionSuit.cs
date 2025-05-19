using proyectoHotel.interfaces;
using proyectoHotel.publishers;

namespace proyectoHotel.clases;

public class HabitacionSuit: Habitacion, IMiniBar
{
    private TipoCama _tipoCama;
    private MiniBar _miniBar;
    
    public enum TipoCama { King, QueenYSemiDoble }
    private Dictionary<string, byte> itemsMiniBar  = new()
    {
        { "botellaVino", 1 },
        { "botellasLicor", 4 },
        { "kitAseo", 3 },
        { "gaseosas", 4 },
        { "batas", 2 }
    };
    
    public static readonly Piso Piso = Piso.P6;
    public static readonly byte MaxHabitaciones = 5;
    private static readonly double CostoNoche = 500_000;
    

    public HabitacionSuit(int numero, Piso piso, Tipo tipo, TipoCama tipoCama, PublisherConsumoMiniBar publisher) : base(numero, piso, tipo, CostoNoche)
    {
        _tipoCama = tipoCama;
        _miniBar = new MiniBar(new Dictionary<string, byte>(itemsMiniBar), publisher);
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
        _miniBar.Consumir(item, cantidad);
    }


}