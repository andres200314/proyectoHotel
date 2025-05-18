using proyectoHotel.interfaces;
using proyectoHotel.publishers;

namespace proyectoHotel.clases;

public class HabitacionEjecutiva: Habitacion, IMiniBar
{
    
    private TipoCama _tipoCama;
    private MiniBar _miniBar;
    
    public enum TipoCama { Queen, DosSemiDobles }
    private Dictionary<string, byte> Minibar  = new()
    {
        { "botellaVino", 0 },
        { "botellasLicor", 4 },
        { "kitAseo", 1 },
        { "gaseosas", 2 },
        { "batas", 0 }
    };
    
    private static readonly byte Piso = 5;
    private static readonly double CostoNoche = 350_000;
    private static readonly byte MaxHabitaciones = 10;
    


    public HabitacionEjecutiva(uint numero, Piso piso, Tipo tipo, double costoNoche, TipoCama tipoCama, PublisherConsumoMiniBar publisher) : base(numero, piso, tipo, costoNoche)
    {
        _tipoCama = tipoCama;
        _miniBar = new MiniBar(Minibar, publisher);
    }

    public void LlenarMiniBar()
    {
        throw new NotImplementedException();
    }
}