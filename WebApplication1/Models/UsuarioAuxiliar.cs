using MusicaLMFL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libreria_V6.Models
{
    public class UsuarioAuxiliar
    {
        public List<TProducto> producto { get; set; }

        public UsuarioAuxiliar(List<TProducto> producto)
        {
            this.producto = producto;
        }

        public UsuarioAuxiliar()
        {
        }
    }
}