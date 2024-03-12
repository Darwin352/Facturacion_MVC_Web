using PRACTICA_AEAE_3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PRACTICA_AEAE_3_MVC.Controllers
{
    public class TBLempleadoController : Controller
    {
        // GET: TBLempleado
        public ActionResult Index()
        {
            BDfacturacion DB=new BDfacturacion();
            var empleados = DB.TBLEMPLEADO;


            return View(empleados.ToList());
        }

        public ActionResult Nuevo()
        {
            BDfacturacion DB = new BDfacturacion();
            ViewBag.IdRolEmpleado = new SelectList(DB.TBLROLES,"IdRolEmpleado","StrDescripcion");
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
                    var NuevosDatos = new TBLEMPLEADO();
                    NuevosDatos.strNombre = collection["strNombre"];
                    NuevosDatos.NumDocumento = long.Parse(collection["NumDocumento"]);
                    NuevosDatos.StrDireccion = collection["StrDireccion"];
                    NuevosDatos.StrTelefono = collection["StrTelefono"];
                    NuevosDatos.StrEmail = collection["StrEmail"];
                    NuevosDatos.IdRolEmpleado = int.Parse(collection["IdRolEmpleado"]);
                    NuevosDatos.DtmIngreso = Convert.ToDateTime(collection["DtmIngreso"]);
                    NuevosDatos.DtmRetiro = Convert.ToDateTime(collection["DtmRetiro"]);
                    NuevosDatos.strDatosAdicionales = collection["strDatosAdicionales"];
                    NuevosDatos.DtmFechaModifica = DateTime.Now.Date;
                    NuevosDatos.StrUsuarioModifico = "Darwin";

                    DB.TBLEMPLEADO.Add(NuevosDatos);
                    DB.SaveChanges();
                    return Redirect("/TBLEmpleado/index");
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
            var DatosEmple = DB.TBLEMPLEADO.Find(id);
            BDfacturacion DB2 = new BDfacturacion();
            ViewBag.IdRolEmpleado = new SelectList(DB2.TBLROLES, "IdRolEmpleado", "StrDescripcion", DatosEmple.IdEmpleado);
            return View(DatosEmple);
        }
        [HttpPost]

        public ActionResult Editar(TBLEMPLEADO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BDfacturacion db = new BDfacturacion())
                    {
                        var DatosModifi = db.TBLEMPLEADO.Find(model.IdEmpleado);
                        DatosModifi.strNombre = model.strNombre;
                        DatosModifi.NumDocumento = model.NumDocumento;
                        DatosModifi.StrDireccion = model.StrDireccion;
                        DatosModifi.StrTelefono = model.StrTelefono;
                        DatosModifi.StrEmail = model.StrEmail;
                        DatosModifi.IdRolEmpleado = model.IdRolEmpleado;
                        DatosModifi.DtmIngreso = model.DtmIngreso;
                        DatosModifi.DtmRetiro = model.DtmRetiro;
                        DatosModifi.strDatosAdicionales = model.strDatosAdicionales;
                        DatosModifi.DtmFechaModifica = DateTime.Now.Date;
                        DatosModifi.StrUsuarioModifico = "Darwin";
                        db.Entry(DatosModifi).State =System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/TBLEmpleado/index");
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
                    var otabla = db.TBLEMPLEADO.Find(id);
                    db.TBLEMPLEADO.Remove(otabla);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Redirect("/TBLEmpleado/index");
        }
    }
}