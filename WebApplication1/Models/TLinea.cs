using MusicaLMFL.Comun;


namespace MusicaLMFL.Modelo
{
    public class TLinea
    {
        public string CodFactura { get; set; }
        public string Producto { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public TLinea(string codFactura, string producto, string cantidad, string total)
        {
            CodFactura = codFactura;
            Producto = producto;
            Cantidad = cantidad;
            Total = total;
        }

        public TLinea(string producto, string cantidad, string total)
        {
            CodFactura = Util.GenerarCodigo(this.GetType());
            Producto = producto;
            Cantidad = cantidad;
            Total = total;
        }

        public TLinea() { }

        public override string ToString()
        {
            return CodFactura + ": " + Producto.ToUpper();
        }

    }   
}
