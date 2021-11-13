using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicineProjects.Filters;
using MedicineProjects.Models;

namespace MedicineProjects.Controllers
{
   
    public class MedicineStocksController : Controller
    {
        private MedicineSalesEntities db = new MedicineSalesEntities();

        // GET: MedicineStocks
        public ActionResult Index()
        {
            var medicineStocks = db.MedicineStocks.Include(m => m.Medicine).Include(m => m.TblSalePoint);
            return View(medicineStocks.ToList());
        }

        // GET: MedicineStocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineStock medicineStock = db.MedicineStocks.Find(id);
            if (medicineStock == null)
            {
                return HttpNotFound();
            }
            return View(medicineStock);
        }

        // GET: MedicineStocks/Create
        public ActionResult Create()
        {
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName");
            ViewBag.SalePointID = new SelectList(db.TblSalePoints, "SalePointID", "SalePointName");
            return View();
        }

        // POST: MedicineStocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicineStockId,MedicineId,SalePointID,Quantity,Status")] MedicineStock medicineStock)
        {
            if (ModelState.IsValid)
            {
                db.MedicineStocks.Add(medicineStock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName", medicineStock.MedicineId);
            ViewBag.SalePointID = new SelectList(db.TblSalePoints, "SalePointID", "SalePointName", medicineStock.SalePointID);
            return View(medicineStock);
        }

        // GET: MedicineStocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineStock medicineStock = db.MedicineStocks.Find(id);
            if (medicineStock == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName", medicineStock.MedicineId);
            ViewBag.SalePointID = new SelectList(db.TblSalePoints, "SalePointID", "SalePointName", medicineStock.SalePointID);
            return View(medicineStock);
        }

        // POST: MedicineStocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicineStockId,MedicineId,SalePointID,Quantity,Status")] MedicineStock medicineStock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicineStock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName", medicineStock.MedicineId);
            ViewBag.SalePointID = new SelectList(db.TblSalePoints, "SalePointID", "SalePointName", medicineStock.SalePointID);
            return View(medicineStock);
        }

        // GET: MedicineStocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineStock medicineStock = db.MedicineStocks.Find(id);
            if (medicineStock == null)
            {
                return HttpNotFound();
            }
            return View(medicineStock);
        }

        // POST: MedicineStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicineStock medicineStock = db.MedicineStocks.Find(id);
            db.MedicineStocks.Remove(medicineStock);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
