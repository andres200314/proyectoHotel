
using System.Globalization;

namespace proyectoHotel.clases;

public class Persona
{
    private string _nombre;
    private TipoDocumentoPersona _tipoDocumento;
    private string _documento;
    private string _numeroTelefono;

    public enum TipoDocumentoPersona { CC, TI, PA, CE }
    public enum TipoPersona
    {
        Cliente, Huesped
    }

    
    public Persona(){}
    public Persona(string nombre, TipoDocumentoPersona tipoDocumento, string documento, string numeroTelefono)
    {
        _nombre = nombre;
        _tipoDocumento = tipoDocumento;
        _documento = documento;
        _numeroTelefono = numeroTelefono;
    }

    public string Nombre
    {
        get => _nombre;
        set => _nombre = value ?? throw new ArgumentNullException(nameof(value));
    }

    public TipoDocumentoPersona TipoDocumento
    {
        get => _tipoDocumento;
        set => _tipoDocumento = value;
    }

    public string NumeroTelefono
    {
        get => _numeroTelefono;
        set => _numeroTelefono = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Documento
    {
        get => _documento;
        set => _documento = value;
    }

    public override string ToString()
    {
        return _nombre;
    }
}