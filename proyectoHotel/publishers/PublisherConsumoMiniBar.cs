﻿namespace proyectoHotel.publishers;

public class PublisherConsumoMiniBar
{
    public delegate void DelegadoConsumo(string item, byte cantidad);
    
    public event DelegadoConsumo? EventoConsumo;
    
    public void PublicarConsumoItem(string item, byte cantidad)
    {
        EventoConsumo?.Invoke(item, cantidad);
    }
}