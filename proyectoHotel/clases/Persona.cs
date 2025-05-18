
using System.Globalization;

namespace proyectoHotel.clases;

public class Persona
{
    private string _nombre;
    private TipoDocumento _tipoDocumento;
    private string _documento;
    private string _numeroTelefono;

    public enum TipoDocumento { CC, TI, PA, CE }

    public Persona(string nombre, TipoDocumento tipoDocumento, string documento, string numeroTelefono)
    {
        _nombre = nombre;
        _tipoDocumento = tipoDocumento;
        _documento = documento;
        _numeroTelefono = numeroTelefono;
    }
}