﻿using System;

namespace MusicaLMFL.Comun
{
    public class Mensaje
    {
        public static string mostrarmensaje(String mensaje, String pagina)
        {
            //Mostramos el mensaje de error
            return "<link rel = stylesheet href= /Content/css/mensaje.css>" +
                   "<div id = openModal class = modalDialog>" +
                   "<div>" +
                   "<a href= " + pagina + " title = Close class = 'close'>X</a>" +
                   "<h2> Mensaje </h2>" +
                   "<p>" + mensaje + "</p>" +
                   "</div>" +
                   "</div>";

        }
    }
}