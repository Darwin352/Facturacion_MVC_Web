using PRACTICA_AEAE_3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRACTICA_AEAE_3_MVC.Controllers
{
    public class TBLclienteController : Controller
    {
        // GET: TBLcliente
        public ActionResult Index()
        {
            BDfacturacion DB = new BDfacturacion();
            var clientes = DB.TBLCLIENTES;

            return View(clientes.ToList());
        }
        public ActionResult Nuevo()
        {
            BDfacturacion DB = new BDfacturacion();
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
                    var NuevosDatos = new TBLCLIENTES();
                    NuevosDatos.StrNombre = collection["strNombre"];
                    NuevosDatos.NumDocumento = long.Parse(collection["NumDocumento"]);
                    NuevosDatos.StrDireccion = collection["StrDireccion"];
                    NuevosDatos.StrTelefono = collection["StrTelefono"];
                    NuevosDatos.StrEmail = collection["StrEmail"];
                    NuevosDatos.DtmFechaModifica = DateTime.Now.Date;
                    NuevosDatos.StrUsuarioModifica = "Darwin";

                    DB.TBLCLIENTES.Add(NuevosDatos);
                    DB.SaveChanges();
                    return Redirect("/TBLcliente/index");
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
            var DatosClien = DB.TBLCLIENTES.Find(id);
            return View(DatosClien);
        }
        [HttpPost]

        public ActionResult Editar(TBLCLIENTES model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BDfacturacion db = new BDfacturacion())
                    {
                        var DatosModifi = db.TBLCLIENTES.Find(model.IdCliente);
                        DatosModifi.StrNombre = model.StrNombre;
                        DatosModifi.NumDocumento = model.NumDocumento;
                        DatosModifi.StrDireccion = model.StrDireccion;
                        DatosModifi.StrTelefono = model.StrTelefono;
                        DatosModifi.StrEmail = model.StrEmail;
                        DatosModifi.DtmFechaModifica = DateTime.Now.Date;
                        DatosModifi.StrUsuarioModifica = "Darwin";
                        db.Entry(DatosModifi).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/TBLcliente/index");
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
                    var otabla = db.TBLCLIENTES.Find(id);
                    db.TBLCLIENTES.Remove(otabla);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Redirect("/TBLCliente/index");
        }
    }
}