using Practica_3.Models;
using System.Web.Mvc;
using System;

public class AbonosController : Controller
{
    private SistemaRegistroEntities db = new SistemaRegistroEntities();


    [HttpGet]
    public ActionResult Registro()
    {
        return View();
    }

    [HttpPost]
    public ActionResult RegistrarAbono(int CompraId, decimal MontoAbono)
    {
        var compra = db.Compras.Find(CompraId);

        if (compra == null || MontoAbono <= 0 || MontoAbono > compra.Saldo)
        {
            TempData["Error"] = "Datos inválidos para el abono.";
            return RedirectToAction("Registro", "Abonos");
        }

        Abonos nuevoAbono = new Abonos
        {
            CompraId = CompraId,
            Monto = MontoAbono,
            Fecha = DateTime.Now
        };

        db.Abonos.Add(nuevoAbono);
        compra.Saldo -= MontoAbono;

        if (compra.Saldo <= 0)
        {
            compra.Estado = "Cancelado";
        }

        db.SaveChanges();

        return RedirectToAction("Consulta", "Compras");
    }
}
