using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Practica_3.Models;

namespace Practica_3.Controllers
{
    public class ComprasController : Controller
    {
        private PracticaS12Entities1 db = new PracticaS12Entities1();

        public ActionResult Consulta()
        {
            var compras = db.Principal.OrderBy(c => c.Estado).ToList();
            return View(compras);
        }

        public JsonResult ObtenerComprasPendientes()
        {
            var compras = db.Principal
                            .Where(c => c.Estado == "Pendiente")
                            .Select(c => new
                            {
                                CompraId = c.Id_Compra, 
                                c.Descripcion,
                                c.Saldo
                            })
                            .ToList();

            return Json(compras, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerSaldo(long compraId)
        {
            var saldo = db.Principal
                          .Where(c => c.Id_Compra == compraId)
                          .Select(c => c.Saldo)
                          .FirstOrDefault();

            return Json(saldo, JsonRequestBehavior.AllowGet);
        }
    }
}
