﻿using System;
using System.Collections.Generic;

namespace MusicaLMFL.Persistencia
{
    interface IAcceso<obj>
    {
        bool Insertar(List<object> objeto);
        bool Borrar(Object objeto);
        bool BorradoVirtual(Object objeto);
        Object Buscar(Type clase, String nombre);
        List<object> Buscar(Type clase, string campo, string busqueda);
        List<object> Obtener(Type clase);
        bool Modificar(String nombre, obj objeto);
    }

}
