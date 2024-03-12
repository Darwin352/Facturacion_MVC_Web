using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRACTICA_AEAE_3_MVC.Models;

namespace PRACTICA_AEAE_3_MVC.Controllers
{
    public class TBLfacturaController : Controller
    {
        // GET: TBLfactura
        public ActionResult Index()
        {
            BDfacturacion DB = new BDfacturacion();
            var factura = DB.TBLFACTURA;
            return View(factura.ToList());
        }

        public ActionResult Nuevo()
        {
            BDfacturacion DB = new BDfacturacion();
            BDfacturacion DB2 = new BDfacturacion();
            BDfacturacion DB3 = new BDfacturacion();
            ViewBag.IdEstado = new SelectList(DB.TBLESTADO_FACTURA, "IdEstadoFactura", "StrDescripcion");
            ViewBag.IdCliente = new SelectList(DB2.TBLCLIENTES, "IdCliente", "StrNombre");
            ViewBag.IdEmpleado = new SelectList(DB3.TBLEMPLEADO, "IdEmpleado", "strNombre");
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
                    var NuevosDatos = new TBLFACTURA();
                    NuevosDatos.DtmFecha = Convert.ToDateTime(collection["DtmFecha"]);
                    NuevosDatos.IdCliente = int.Parse(collection["IdCliente"]);
                    NuevosDatos.IdEmpleado = int.Parse(collection["IdEmpleado"]);
                    NuevosDatos.NumDescuento = float.Parse(collection["NumDescuento"]);
                    NuevosDatos.NumImpuesto = float.Parse(collection["NumImpuesto"]);
                    NuevosDatos.NumValorTotal = float.Parse(collection["NumValorTotal"]);
                    NuevosDatos.IdEstado = int.Parse(collection["IdEstado"]);
                    NuevosDatos.DtmFechaModifica = DateTime.Now.Date;
                    NuevosDatos.StrUsuarioModifica = "Darwin";

                    DB.TBLFACTURA.Add(NuevosDatos);
                    DB.SaveChanges();
                    return Redirect("/TBLfactura/index");
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
            var DatosFactu = DB.TBLFACTURA.Find(id);
            BDfacturacion DB1 = new BDfacturacion();
            BDfacturacion DB2 = new BDfacturacion();
            BDfacturacion DB3 = new BDfacturacion();
            ViewBag.IdEstado = new SelectList(DB1.TBLESTADO_FACTURA, "IdEstadoFactura", "StrDescripcion");
            ViewBag.IdCliente = new SelectList(DB2.TBLCLIENTES, "IdCliente", "StrNombre");
            ViewBag.IdEmpleado = new SelectList(DB3.TBLEMPLEADO, "IdEmpleado", "strNombre");
            return View(DatosFactu);
        }
        [HttpPost]

        public ActionResult Editar(TBLFACTURA model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BDfacturacion db = new BDfacturacion())
                    {
                        var DatosModifi = db.TBLFACTURA.Find(model.IdFactura);
                        DatosModifi.DtmFecha = model.DtmFecha;
                        DatosModifi.IdCliente = model.IdCliente;
                        DatosModifi.IdEmpleado = model.IdEmpleado;
                        DatosModifi.NumDescuento = model.NumDescuento;
                        DatosModifi.NumImpuesto = model.NumImpuesto;
                        DatosModifi.NumValorTotal = model.NumValorTotal;
                        DatosModifi.IdEstado = model.IdEstado;
                        DatosModifi.DtmFechaModifica = DateTime.Now.Date;
                        DatosModifi.StrUsuarioModifica = "Darwin";
                        db.Entry(DatosModifi).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/TBLfactura/index");
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
                    var otabla = db.TBLFACTURA.Find(id);
                    db.TBLFACTURA.Remove(otabla);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Redirect("/TBLfactura/index");
        }
    }
}