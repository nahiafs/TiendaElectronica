using MusicaLMFL.Models;

namespace MusicaLMFL.Modelo
{
    public class LineaAuxiliar
    {
        public string CodFactura { get; set; }
        public TProducto Producto { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public LineaAuxiliar(string codFactura, TProducto producto, string cantidad, string total)
        {
            CodFactura = codFactura;
            Producto = producto;
            Cantidad = cantidad;
            Total = total;
        }

        public LineaAuxiliar()
        {

        }

        public double subTotal()
        {
            return double.Parse(Total.Replace('.', ','));
        }
        
    }
}
