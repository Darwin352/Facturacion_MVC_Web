using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRACTICA_AEAE_3_MVC.Models;

namespace PRACTICA_AEAE_3_MVC.Controllers
{
    public class TBLproductoController : Controller
    {
        // GET: TBLproducto
        public ActionResult Index()
        {
            BDfacturacion DB = new BDfacturacion();
            var producto = DB.TBLPRODUCTO;
            return View(producto.ToList());
        }

        public ActionResult Nuevo()
        {
            BDfacturacion DB = new BDfacturacion();
            ViewBag.IdCategoria = new SelectList(DB.TBLCATEGORIA_PROD, "IdCategoria", "StrDescripcion");
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BDfacturacion DB = new BDfacturacion();
                    var NuevosDatos = new TBLPRODUCTO();
                    NuevosDatos.StrNombre = collection["strNombre"];
                    NuevosDatos.StrCodigo = collection["StrCodigo"];
                    NuevosDatos.NumPrecioCompra = float.Parse(collection["NumPrecioCompra"]);
                    NuevosDatos.NumPrecioVenta = float.Parse(collection["NumPrecioVenta"]);
                    NuevosDatos.IdCategoria = int.Parse(collection["IdCategoria"]);
                    NuevosDatos.StrDetalle = collection["StrDetalle"];
                    NuevosDatos.strFoto = collection["strFoto"];
                    NuevosDatos.NumStock = int.Parse(collection["NumStock"]);
                    NuevosDatos.DtmFechaModifica = DateTime.Now.Date;
                    NuevosDatos.StrUsuarioModifica = "Darwin";

                    DB.TBLPRODUCTO.Add(NuevosDatos);
                    DB.SaveChanges();
                    return Redirect("/TBLproducto/index");
                }

                return View(collection);

            }
            catch (Exception ex)

            {
                throw new Exception(ex.Message);
            }

        }

        public ActionResult Editar(int id)
        {
            BDfacturacion DB = new BDfacturacion();
            var DatosProd = DB.TBLPRODUCTO.Find(id);
            BDfacturacion DB2 = new BDfacturacion();
            ViewBag.IdCategoria = new SelectList(DB2.TBLCATEGORIA_PROD, "IdCategoria", "StrDescripcion", DatosProd.IdCategoria);
            return View(DatosProd);
        }
        [HttpPost]

        public ActionResult Editar(TBLPRODUCTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BDfacturacion db = new BDfacturacion())
                    {
                        var DatosModifi = db.TBLPRODUCTO.Find(model.IdProducto);
                        DatosModifi.StrNombre = model.StrNombre;
                        DatosModifi.StrCodigo = model.StrCodigo;
                        DatosModifi.NumPrecioCompra = model.NumPrecioCompra;
                        DatosModifi.NumPrecioVenta = model.NumPrecioVenta;
                        DatosModifi.IdCategoria = model.IdCategoria;
                        DatosModifi.StrDetalle = model.StrDetalle;
                        DatosModifi.strFoto = model.strFoto;
                        DatosModifi.NumStock = model.NumStock;
                        DatosModifi.DtmFechaModifica = DateTime.Now.Date;
                        DatosModifi.StrUsuarioModifica = "Darwin";
                        db.Entry(DatosModifi).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/TBLproducto/index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Borrar(int id)
        {
            try
            {
                using (BDfacturacion db = new BDfacturacion())
                {
                    var otabla = db.TBLPRODUCTO.Find(id);
                    db.TBLPRODUCTO.Remove(otabla);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Redirect("/TBLproducto/index");
        }
    }
}