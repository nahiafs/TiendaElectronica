

namespace MusicaLMFL.Modelo
{
    public class TLineaFactura
    {

        public string CodFactura { get; set; }
        public string Producto { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public TLineaFactura(string codFactura, string producto, string cantidad, string total)
        {
            CodFactura = codFactura;
            Producto = producto;
            Cantidad = cantidad;
            Total = total;
        }
        public TLineaFactura()
        {

        }

        public float subTotal()
        {
            return float.Parse(Total);
        }

        public override string ToString()
        {
            return Producto + " "+Cantidad+" "+Total;
        }
        public override bool Equals(object obj)
        {
            return ((TLineaFactura)obj).Producto == Producto;
        }
    }
}
