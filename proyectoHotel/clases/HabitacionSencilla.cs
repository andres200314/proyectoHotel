namespace proyectoHotel.clases;

public class HabitacionSencilla: Habitacion
{
    private TipoCama _tipoCama;
    
    
    public enum TipoCama { Doble, DosSencillas }
    private static readonly double PRECIO = 200_000;
    
    
    public HabitacionSencilla(uint numero, byte piso, double precio, TipoCama tipoCama) : base(numero, piso, PRECIO)
    {
        _tipoCama = tipoCama;
    }
}