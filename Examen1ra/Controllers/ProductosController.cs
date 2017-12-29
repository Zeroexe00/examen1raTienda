using Examen1ra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen1ra.Controllers
{
    public class ProductosController : Controller
    {
        Examen1ra.Models.TiendaEntities cnx;
    
    public ProductosController() {
            cnx = new Models.TiendaEntities();

        }


        public ActionResult Listado()
    {

        return View(cnx.Productos.ToList());
    }

    public ActionResult Mantenedor()
    {

        return View();
    }
    public ActionResult Guardar(int codigobarra, string nombre, string familia, int precio, int descuentomax, string descripcion)
    {
        Productos nuevo = new Productos()
        {
            codigobarra = codigobarra,
            nombre = nombre,
            familia = familia,
            precio = precio,
            descuentomax = descuentomax,
            descripcion=descripcion
        };
        cnx.Productos.Add(nuevo);
        cnx.SaveChanges();

        return View("Listado", cnx.Productos.ToList());
    }

    public ActionResult Ficha(int codigobarra)
    {

        return View(cnx.Productos.Where(x => x.codigobarra == codigobarra).First());
    }

}
}
