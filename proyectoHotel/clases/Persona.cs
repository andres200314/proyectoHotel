
using System.Globalization;

namespace proyectoHotel.clases;

public class Persona
{
    private string _nombre;
    private TipoDocumento _tipoDocumento;
    private string _documento;
    private string _numeroTelefono;

    private enum TipoDocumento { CC, TI, PA, CE }
}