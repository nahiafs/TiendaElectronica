using MusicaLMFL.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicaLMFL.Models
{
    public class TProducto
    {
        public string CodProducto { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string Precio { get; set; }
        public string Estado { get; set; }
        public string Imagen { get; set; }
        public string Borrado { get; set; }

        public TProducto() { }

        public TProducto(string codProducto, string nombre, string marca, string categoria, string precio, string estado, string imagen, string borrado)
        {
            CodProducto = codProducto;
            Nombre = nombre;
            Marca = marca;
            Categoria = categoria;
            Precio = precio;
            Estado = estado;
            Imagen = imagen;
            Borrado = borrado;
        }

        public TProducto(string nombre, string marca, string categoria, string precio, string estado, string imagen)
        {
            CodProducto = Util.GenerarCodigo(this.GetType());
            Nombre = nombre;
            Marca = marca;
            Categoria = categoria;
            Precio = precio;
            Estado = estado;
            Imagen = imagen;
            Borrado = "0";
        }

        public override string ToString()
        {
            return CodProducto + " " + Precio;
        }
    }
}