using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicaLMFL.Models
{
    public class TCategoria
    {
        public string Categoria { get; set; }
        public string Borrado { get; set; }

        public TCategoria() { }

        public TCategoria(string categoria)
        {
            this.Categoria = categoria;
        }
    }
}