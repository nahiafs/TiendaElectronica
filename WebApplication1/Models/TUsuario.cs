﻿using MusicaLMFL.Comun;

namespace MusicaLMFL.Modelo
{
    public class TUsuario
    {

        public string CodUsuario { get; set; }
        public string Nick { get; set; }
        public string Pass { get; set; }
        public string Rol { get; set; }

        public TUsuario(string codUsuario, string nick, string pass, string rol)
        {
            CodUsuario = codUsuario;
            Nick = nick;
            Pass = pass;
            Rol = rol;
        }

        public TUsuario(string nick, string pass, string rol)
        {
            CodUsuario = Util.GenerarCodigo(new TUsuario().GetType());
            Nick = nick;
            Pass = pass;
            Rol = rol;
        }

        public TUsuario()
        { }
    }
}