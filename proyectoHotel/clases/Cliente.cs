namespace proyectoHotel.clases;

public class Cliente: Persona
{
    private string _codigoFidelidad;

    public Cliente(string nombre, TipoDocumento tipoDocumento, string documento, string numeroTelefono) : base(nombre, tipoDocumento, documento, numeroTelefono)
    {
        _codigoFidelidad = "codigoFidelidad";
    }
}