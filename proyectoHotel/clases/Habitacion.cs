namespace proyectoHotel.clases
{
    public abstract class Habitacion
    {
        private int _numero;
        private Piso _piso;
        private Tipo _tipo;
        private double _costoNoche;
        private bool _ocupada;
        private List<(string, double)> _consumos;

        public enum Piso { P1, P2, P3, P4, P5, P6 }

        public enum Tipo { Sencilla, Ejecutiva, Suit }

        private ServicioRestaurante _servicioRestaurante;
        private ServicioLavanderia _servicioLavanderia;

        protected Habitacion(int numero, Piso piso, Tipo tipo, double costoNoche)
        {
            _numero = numero;
            _piso = piso;
            _tipo = tipo;
            _costoNoche = costoNoche;
            _ocupada = false;
            _consumos = new();
        }

        public int Numero => _numero;

        public bool Ocupada
        {
            get => _ocupada;
            set => _ocupada = value;
        }

        public double CostoNoche => _costoNoche;

        public List<(string, double)> Consumos => _consumos;

        public void PedirComida(string platillo, byte cantidad, bool servicioHabitacion)
        {
            try
            {
                var pedido = _servicioRestaurante.PedirComida(platillo, cantidad, servicioHabitacion);
                _consumos.Add((pedido.Item1, pedido.Item2));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al pedir comida en la habitación {_numero}: {ex.Message}", ex);
            }
        }

        public void Lavanderia(byte cantidadPrendas, bool planchado)
        {
            try
            {
                var lavado = _servicioLavanderia.PedirServicio(cantidadPrendas, planchado);
                _consumos.Add((lavado.Item1, lavado.Item2));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el servicio de lavandería de la habitación {_numero}: {ex.Message}", ex);
            }
        }
    }
}
