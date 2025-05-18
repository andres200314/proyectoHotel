using proyectoHotel.interfaces;
using proyectoHotel.publishers;

namespace proyectoHotel.clases;

public class HabitacionSuit: Habitacion, IMiniBar
{
    private TipoCama _tipoCama;
    private MiniBar _miniBar;
    
    public enum TipoCama { King, QueenYSemiDoble }
    private Dictionary<string, byte> Minibar  = new()
    {
        { "botellaVino", 1 },
        { "botellasLicor", 4 },
        { "kitAseo", 3 },
        { "gaseosas", 4 },
        { "batas", 2 }
    };
    
    private static readonly byte Piso = 6;
    private static readonly double CostoNoche = 500_000;
    private static readonly byte MaxHabitaciones = 5;
    

    public HabitacionSuit(uint numero, Piso piso, Tipo tipo, TipoCama tipoCama, PublisherConsumoMiniBar publisher) : base(numero, piso, tipo, CostoNoche)
    {
        _tipoCama = tipoCama;
        _miniBar = new MiniBar(Minibar, publisher);
    }

    public void LlenarMiniBar()
    {
        throw new NotImplementedException();
    }
}