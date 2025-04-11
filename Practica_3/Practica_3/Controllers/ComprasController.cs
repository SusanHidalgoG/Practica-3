using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Practica_3.Models;

namespace Practica_3.Controllers
{
    public class ComprasController : Controller
    {
        private SistemaRegistroEntities db = new SistemaRegistroEntities();

   
        public ActionResult Consulta()
        {
            var compras = db.Compras.OrderBy(c => c.Estado).ToList();
            return View(compras);
        }

        public JsonResult ObtenerComprasPendientes()
        {
            var compras = db.Compras
                            .Where(c => c.Estado == "Pendiente")
                            .Select(c => new
                            {
                                c.CompraId,
                                c.Descripcion,
                                c.Saldo
                            })
                            .ToList();

            return Json(compras, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerSaldo(int compraId)
        {
            var saldo = db.Compras
                          .Where(c => c.CompraId == compraId)
                          .Select(c => c.Saldo)
                          .FirstOrDefault();

            return Json(saldo, JsonRequestBehavior.AllowGet);
        }
    }
}
