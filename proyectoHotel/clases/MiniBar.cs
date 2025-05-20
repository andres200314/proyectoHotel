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

    public (string, double) Consumir(string item, byte cantidad)
    {
        if (!_productos.ContainsKey(item))
        {
            throw new InvalidOperationException($"El item '{item}' no existe en el minibar.");
        }

        if (_productos[item] < cantidad)
        {
            throw new InvalidOperationException($"Stock insuficiente de '{item}'. Disponible: {_productos[item]}");
        }

        _productos[item] -= cantidad;
        int precioUnitario = PreciosMinibar.Precios[item];
        int totalConsumo = precioUnitario * cantidad;

        _publisher.PublicarConsumoItem(item, cantidad);
        return ("MiniBar", totalConsumo);
    }
}