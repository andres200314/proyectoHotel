
using System.Globalization;

namespace proyectoHotel.clases;

public class Persona
{
    private enum TipoDocumento { CC, TI, PA, CE }
    
    
    private string _nombre;
    private TipoDocumento _tipoDocumento;
    private string _documento;
    private string _numeroTelefono;
}