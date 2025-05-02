namespace proyectoHotel.clases;

public class MiniBar
{
    private int _licor;
    private int _vino;
    private int _agua;
    private int _gaseosa;
    private int _kitAseo;

    public int Licor
    {
        get => _licor;
        set => _licor = value;
    }

    public int Vino
    {
        get => _vino;
        set => _vino = value;
    }

    public int Agua
    {
        get => _agua;
        set => _agua = value;
    }

    public int Gaseosa
    {
        get => _gaseosa;
        set => _gaseosa = value;
    }

    public int KitAseo
    {
        get => _kitAseo;
        set => _kitAseo = value;
    }
}