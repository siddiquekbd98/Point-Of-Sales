using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicineProjects.Models;

namespace MedicineProjects.Controllers
{
    public class MedicineSalesController : Controller
    {
        private MedicineSalesEntities db = new MedicineSalesEntities();

        // GET: MedicineSales
        public ActionResult Index()
        {
            var MedicineSales = db.MedicineSales.Include(s => s.Customer).Include(s => s.TblSalePoint).Include(s => s.Medicine);
            return View(MedicineSales.ToList());
        }

        // GET: MedicineSales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineSale MedicineSale = db.MedicineSales.Find(id);
            if (MedicineSale == null)
            {
                return HttpNotFound();
            }
            return View(MedicineSale);
        }

        // GET: MedicineSales/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            ViewBag.SalePointID = new SelectList(db.TblSalePoints, "SalePointID", "SalePointName");
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName");
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName");
            ViewBag.MedicineSaleId = new SelectList(db.MedicineSales, "MedicineSaleId", "MedicineStockStatus");
            ViewBag.MedicineSaleId = new SelectList(db.MedicineSales, "MedicineSaleId", "MedicineStockStatus");
            return View();
        }

        // POST: MedicineSales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicineSaleId,MedicineId,CustomerId,SalePointID,SaleDate,ExpireDate,Rate,Quantity,TotalPrice,Vat,Discount,NetotalPrice,MedicineStockStatus,MemoNo,Comments")] MedicineSale MedicineSale)
        {
            if (ModelState.IsValid)
            {
                db.MedicineSales.Add(MedicineSale);

                // update stock
                var oStock = (from o in db.MedicineStocks where o.MedicineId == MedicineSale.MedicineId select o).FirstOrDefault();
                if (oStock != null)
                {
                    oStock.Quantity -= MedicineSale.Quantity;
                    oStock.Status = "out";
                }
                // end of update stock

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", MedicineSale.CustomerId);
            ViewBag.SalePointID = new SelectList(db.TblSalePoints, "SalePointID", "SalePointName", MedicineSale.SalePointID);
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName", MedicineSale.MedicineId);
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName", MedicineSale.MedicineId);
            ViewBag.MedicineSaleId = new SelectList(db.MedicineSales, "MedicineSaleId", "MedicineStockStatus", MedicineSale.MedicineSaleId);
            ViewBag.MedicineSaleId = new SelectList(db.MedicineSales, "MedicineSaleId", "MedicineStockStatus", MedicineSale.MedicineSaleId);
            return View(MedicineSale);
        }

        // GET: MedicineSales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineSale MedicineSale = db.MedicineSales.Find(id);
            if (MedicineSale == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", MedicineSale.CustomerId);
            ViewBag.SalePointID = new SelectList(db.TblSalePoints, "SalePointID", "SalePointName", MedicineSale.SalePointID);
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName", MedicineSale.MedicineId);
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName", MedicineSale.MedicineId);
            ViewBag.MedicineSaleId = new SelectList(db.MedicineSales, "MedicineSaleId", "MedicineStockStatus", MedicineSale.MedicineSaleId);
            ViewBag.MedicineSaleId = new SelectList(db.MedicineSales, "MedicineSaleId", "MedicineStockStatus", MedicineSale.MedicineSaleId);
            return View(MedicineSale);
        }

        // POST: MedicineSales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicineSaleId,MedicineId,CustomerId,SalePointID,SaleDate,ExpireDate,Rate,Quantity,TotalPrice,Vat,Discount,NetotalPrice,MedicineStockStatus,MemoNo,Comments")] MedicineSale MedicineSale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(MedicineSale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", MedicineSale.CustomerId);
            ViewBag.SalePointID = new SelectList(db.TblSalePoints, "SalePointID", "SalePointName", MedicineSale.SalePointID);
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName", MedicineSale.MedicineId);
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName", MedicineSale.MedicineId);
            ViewBag.MedicineSaleId = new SelectList(db.MedicineSales, "MedicineSaleId", "MedicineStockStatus", MedicineSale.MedicineSaleId);
            ViewBag.MedicineSaleId = new SelectList(db.MedicineSales, "MedicineSaleId", "MedicineStockStatus", MedicineSale.MedicineSaleId);
            return View(MedicineSale);
        }

        // GET: MedicineSales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineSale MedicineSale = db.MedicineSales.Find(id);
            if (MedicineSale == null)
            {
                return HttpNotFound();
            }
            return View(MedicineSale);
        }

        // POST: MedicineSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicineSale sale = db.MedicineSales.Find(id);

            // update stock
            var oStock = (from o in db.MedicineStocks where o.MedicineId == sale.MedicineId select o).FirstOrDefault();
            if (oStock != null)
            {
                oStock.Quantity += sale.Quantity;
                oStock.Status = "in";
            }
            // end of update stock

            db.MedicineSales.Remove(sale);
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
