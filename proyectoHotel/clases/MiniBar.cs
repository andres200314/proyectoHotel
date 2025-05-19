using proyectoHotel.publishers;

namespace proyectoHotel.clases;

public class MiniBar
{
    public static class PreciosMinibar
    {
        public static readonly Dictionary<string, int> Precios = new()
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
    public Dictionary<string, byte> Productos => _productos;

    private PublisherConsumoMiniBar _publisher;

    public MiniBar(Dictionary<string, byte> productos, PublisherConsumoMiniBar publisher)
    {
        _productos = new Dictionary<string, byte>(productos);
        _publisher = publisher;
    }

    public void Consumir(string item, byte cantidad)
    {
        if (_productos.ContainsKey(item) && _productos[item] >= cantidad)
        {
            _productos[item] -= cantidad;

            // Dispara el evento de consumo
            _publisher.PublicarConsumoItem(item, cantidad);
        }
        else
        {
            Console.WriteLine($"No se pudo consumir '{item}' - stock insuficiente o no existe.");
        }
    }
}