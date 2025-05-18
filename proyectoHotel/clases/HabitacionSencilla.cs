namespace proyectoHotel.clases;

public class HabitacionSencilla: Habitacion
{
    private TipoCama _tipoCama;
    
    
    public enum TipoCama { Doble, DosSencillas }
    
    
    private static readonly byte MinPiso = 2;
    private static readonly byte MaxPiso = 4;
    private static readonly double CostoNoche = 200_000;
    private static readonly byte MaxHabitaciones = 30;
    


    public HabitacionSencilla(uint numero, Piso piso, Tipo tipo, TipoCama tipoCama) : base(numero, piso, tipo, CostoNoche)
    {
        _tipoCama = tipoCama;
    }
}