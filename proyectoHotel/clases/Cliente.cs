namespace proyectoHotel.clases;

public class Cliente: Persona
{
    private string _codigoFidelidad;

    public Cliente(string nombre, TipoDocumentoPersona tipoDocumento, string documento, string numeroTelefono) : base(nombre, tipoDocumento, documento, numeroTelefono)
    {
        _codigoFidelidad = "codigoFidelidad";
    }
    
    public string CodigoFidelidad => _codigoFidelidad;
}
