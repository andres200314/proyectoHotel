namespace proyectoHotel.clases;

public class HabitacionSencilla: Habitacion
{
    private TipoCama _tipoCama;
    
    
    public enum TipoCama { Doble, DosSencillas }
    
    
    public static readonly byte MinPiso = 2;
    public static readonly byte MaxPiso = 4;
    public static readonly byte MaxHabitaciones = 30;
    private static readonly double CostoNoche = 200_000;
    
    


    public HabitacionSencilla(int numero, Piso piso, Tipo tipo, TipoCama tipoCama) : base(numero, piso, tipo, CostoNoche)
    {
        _tipoCama = tipoCama;
    }
}