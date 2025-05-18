namespace proyectoHotel.clases;

public class MiniBar
{
    public static class PreciosMinibar
    {
        public static readonly Dictionary<string, int> Items = new()
        {
            { "botellasLicor", 25000 },
            { "botellaVino", 50000 },
            { "kitAseo", 9000 },
            { "botellasAgua", 3500 },
            { "gaseosas", 3000 },
            { "batas", 70000 }
        };
    }

    private Dictionary<string, byte> _productos;

    public MiniBar(Dictionary<string, byte> productos)
    {
        _productos = productos;
    }

    private void ManejarConsumo(string item, byte cantidad)
    {
        
    }
}