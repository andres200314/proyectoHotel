namespace proyectoHotel.clases;

public class HabitacionSencilla: Habitacion
{
    private TipoCamaSencilla _tipoCama;
    
    
    public enum TipoCamaSencilla { Doble, DosSencillas }
    
    
    public static readonly byte MinPiso = 2;
    public static readonly byte MaxPiso = 4;
    public static readonly byte MaxHabitaciones = 30;
    private static readonly double _CostoNoche = 200_000;
    
    


    public HabitacionSencilla(int numero, Pisos piso, TipoHabitacion tipo, TipoCamaSencilla tipoCama) : base(numero, piso, tipo, _CostoNoche)
    {
        _tipoCama = tipoCama;
    }
    
    public static double CostoNoche => _CostoNoche;

    public TipoCamaSencilla TipoCama
    {
        get => _tipoCama;
        set => _tipoCama = value;
    }
}