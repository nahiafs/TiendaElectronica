using MusicaLMFL.Comun;
using MusicaLMFL.Modelo;
using MusicaLMFL.Models;
using MusicaLMFL.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicaLMFL.Controllers
{
    public class ProductoController : Controller
    {
        private ControlAccesoDAO<TProducto> control = new ControlAccesoDAO<TProducto>();

        public ActionResult Aniadir()
        {
            return View(control.Obtener(new TCategoria().GetType()));
        }

        [HttpPost]
        public ActionResult Aniadir(TProducto producto)
        {
            try
            {
                List<object> productos = new List<object>();

                producto.CodProducto = Util.GenerarCodigo(new TProducto().GetType());
                producto.Precio = producto.Precio.Replace(".", ",");
                producto.Estado = producto.Estado == null ? "desconocido" : producto.Estado;
                producto.Borrado = "0";

                productos.Add((TProducto) producto);

                if (control.Insertar(productos))
                {
                    return Json("Producto insertado correctamente");
                }
            }
            catch (Exception e)
            {
                return Json(Errores.ControlErrores(e));
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Consultar()
        {
            List<TProducto> lista = new List<TProducto>();

            foreach (TProducto producto in control.Obtener(new TProducto().GetType()))
            {
                lista.Add(producto);
            }

            return View(lista);
        }

        public ActionResult ConsultaPorCategoria(string categoria)
        {
            List<TProducto> lista = new List<TProducto>();

            foreach (TProducto producto in control.Buscar(new TProducto().GetType(), "Categoria", categoria))
            {
                if (producto.Borrado.Equals("0"))
                {
                    lista.Add(producto);
                }
            }

            return View(lista);
        }

        public ActionResult Modificar(String CodProducto)
        {
            object[] lista = new object[2];
            lista[0] = control.Buscar(new TProducto().GetType(), CodProducto);
            lista[1] = control.Obtener(new TCategoria().GetType());
                
            return View(lista);
        }

        [HttpPost]
        public ActionResult Modificar(TProducto producto)
        {
            try
            {
                producto.Borrado = "0";
                control.Modificar(producto.CodProducto, producto);
                return RedirectToAction("Consultar");
            }
            catch (Exception e)
            {
                return Json(Errores.ControlErrores(e));
            }
        }

        public ActionResult Eliminar(String CodProducto)
        {
            control.BorradoVirtual((TProducto)control.Buscar(new TProducto().GetType(), CodProducto));
            object[] modelos = new object[1];
            modelos[0] = control.Obtener(new TProducto().GetType());
            return PartialView("_Borrar", modelos);
        }

        public ActionResult verProducto(String CodProducto)
        {
            TProducto producto = (TProducto) control.Buscar(new TProducto().GetType(), CodProducto);
            return View("verProducto", producto);
        }

        public ActionResult CarritoCompra()
        {
            List<TProducto> lista = new List<TProducto>();

            foreach (TProducto producto in control.Obtener(new TProducto().GetType()))
            {
                lista.Add(producto);
            }

            return View(lista);
        }

        [HttpPost]
        public ActionResult obtenerProducto(string CodProducto)
        {
            object[] modelos = new object[1];
            modelos[0] = (TProducto) control.Buscar(new TProducto().GetType(), CodProducto);
            return Json(modelos);
        }

        [HttpPost]
        public ActionResult comprar(List<TLinea> data)
        {
            TFactura factura = new TFactura("", ((TUsuario)Session["usuario"]).Nick, DateTime.Now.ToShortDateString());
            factura.CodFactura = Util.GenerarCodigo(factura.GetType());
            List<object> listaFacturaTemp = new List<object>();
            listaFacturaTemp.Add(factura);
            List<object> listaLineasFactura = new List<object>();

            foreach (TLinea linea in data)
            {
                TLineaFactura lineaTemp = new TLineaFactura(factura.CodFactura, linea.Producto, linea.Cantidad.ToString(), linea.Total.ToString());
                listaLineasFactura.Add(lineaTemp);
            }

            control.Insertar(listaLineasFactura);
            control.Insertar(listaFacturaTemp);
            return Json("Factura guardada correctamente");
        }
    }
}
