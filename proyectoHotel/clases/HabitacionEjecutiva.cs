using proyectoHotel.interfaces;

namespace proyectoHotel.clases;

public class HabitacionEjecutiva: Habitacion, IMiniBar
{
    
    private TipoCama _tipoCama;
    private MiniBar _miniBar;
    public enum TipoCama { Queen, DosSemiDobles }
    
    
    public HabitacionEjecutiva(uint numero, TipoCama tipoCama)
        : base(numero, 5, 350000)
    {
        _tipoCama = tipoCama;
        _miniBar = new MiniBar();
        LlenarMiniBar();
    }


    public void LlenarMiniBar()
    {
        throw new NotImplementedException();
    }
}