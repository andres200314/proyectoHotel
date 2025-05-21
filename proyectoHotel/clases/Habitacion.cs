namespace proyectoHotel.clases
{
    public abstract class Habitacion
    {
        private int _numero;
        private Pisos _piso;
        private TipoHabitacion _tipo;
        private double _costoNoche;
        private bool _ocupada;
        private List<(string, double)> _consumos;

        public enum Pisos { P1, P2, P3, P4, P5, P6 }

        public enum TipoHabitacion { Sencilla, Ejecutiva, Suit }

        private readonly ServicioRestaurante _servicioRestaurante = new();
        private readonly ServicioLavanderia _servicioLavanderia = new();

        protected Habitacion(int numero, Pisos piso, TipoHabitacion tipo, double costoNoche)
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

        public Pisos Piso
        {
            get => _piso;
            set => _piso = value;
        }

        public TipoHabitacion Tipo
        {
            get => _tipo;
            set => _tipo = value;
        }

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
        
        public override string ToString()
        {
            return $"Habitacion {_tipo} {_numero}";
        }
    }
}
