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
    public class MedicinePurchasesController : Controller
    {
        private MedicineSalesEntities db = new MedicineSalesEntities();

        // GET: MedicinePurchases
        public ActionResult Index()
        {
            var MedicinePurchases = db.MedicinePurchases.Include(p => p.Medicine).Include(p => p.TblSalePoint).Include(p => p.MedicineSupplier);
            return View(MedicinePurchases.ToList());
        }

        // GET: MedicinePurchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicinePurchase MedicinePurchase = db.MedicinePurchases.Find(id);
            if (MedicinePurchase == null)
            {
                return HttpNotFound();
            }
            return View(MedicinePurchase);
        }

        // GET: MedicinePurchases/Create
        public ActionResult Create()
        {
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName");
            ViewBag.SalePointID = new SelectList(db.TblSalePoints, "SalePointID", "SalePointName");
            ViewBag.MedicineSupplierId = new SelectList(db.MedicineSuppliers, "MedicineSupplierId", "MedicineSupplierName");
            return View();
        }

        // POST: MedicinePurchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicinePurchaseId,MedicineId,MedicineSupplierId,SalePointID,PurchaseDate,ExpireDate,UnitPrice,Quantity,TotalPrice,Vat,GrandTotalPrice,MedicineStockStatus,MemoNo,Comments")] MedicinePurchase MedicinePurchase)
        {
            if (ModelState.IsValid)
            {

                MedicinePurchase oMedicinePurchase = new MedicinePurchase();
                // insert into MedicinePurchase
                //oMedicinePurchase.UnitPrice = MedicinePurchase.UnitPrice;
                //oMedicinePurchase.grand_total_price = MedicinePurchase.UnitPrice * MedicinePurchase.Quantity+MedicinePurchase.vat;
                db.MedicinePurchases.Add(MedicinePurchase);

                // update MedicineStock
                var oMedicineStock = (from o in db.MedicineStocks where o.MedicineId == MedicinePurchase.MedicineId select o).FirstOrDefault();
                if (oMedicineStock == null)
                {
                    oMedicineStock = new MedicineStock();
                    oMedicineStock.MedicineId = MedicinePurchase.MedicineId;
                    oMedicineStock.Quantity = MedicinePurchase.Quantity;
                    oMedicineStock.SalePointID = MedicinePurchase.SalePointID;
                    oMedicineStock.Status = "in";
                    db.MedicineStocks.Add(oMedicineStock);
                }
                else
                {
                    oMedicineStock.Quantity += MedicinePurchase.Quantity;
                    oMedicineStock.Status = "in";
                }
                // end of update MedicineStock

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName", MedicinePurchase.MedicineId);
            ViewBag.SalePointID = new SelectList(db.TblSalePoints, "SalePointID", "SalePointName", MedicinePurchase.SalePointID);
            ViewBag.MedicineSupplierId = new SelectList(db.MedicineSuppliers, "MedicineSupplierId", "MedicineSupplierName", MedicinePurchase.MedicineSupplierId);
            return View(MedicinePurchase);

        }

        // GET: MedicinePurchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicinePurchase MedicinePurchase = db.MedicinePurchases.Find(id);
            if (MedicinePurchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName", MedicinePurchase.MedicineId);
            ViewBag.SalePointID = new SelectList(db.TblSalePoints, "SalePointID", "SalePointName", MedicinePurchase.SalePointID);
            ViewBag.MedicineSupplierId = new SelectList(db.MedicineSuppliers, "MedicineSupplierId", "MedicineSupplierName", MedicinePurchase.MedicineSupplierId);
            return View(MedicinePurchase);
        }

        // POST: MedicinePurchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicinePurchase_id,MedicineId,MedicineSupplierId,SalePointID,PurchaseDate,ExpireDate,UnitPrice,Quantity,TotalPrice,Vat,GrandTotalPrice,MedicineStockStatus,MemoNo,Comments")] MedicinePurchase MedicinePurchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(MedicinePurchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "MedicineName", MedicinePurchase.MedicineId);
            ViewBag.SalePointID = new SelectList(db.TblSalePoints, "SalePointID", "SalePointName", MedicinePurchase.SalePointID);
            ViewBag.MedicineSupplierId = new SelectList(db.MedicineSuppliers, "MedicineSupplierId", "MedicineSupplierName", MedicinePurchase.MedicineSupplierId);
            return View(MedicinePurchase);
        }

        // GET: MedicinePurchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicinePurchase MedicinePurchase = db.MedicinePurchases.Find(id);
            if (MedicinePurchase == null)
            {
                return HttpNotFound();
            }
            return View(MedicinePurchase);
        }

        // POST: MedicinePurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicinePurchase MedicinePurchase = db.MedicinePurchases.Find(id);
            // update MedicineStock
            var oMedicineStock = (from o in db.MedicineStocks where o.MedicineId == MedicinePurchase.MedicineId select o).FirstOrDefault();
            if (oMedicineStock != null)
            {
                oMedicineStock.Quantity -= MedicinePurchase.Quantity;
                oMedicineStock.Status = "out";
            }
            // end of update MedicineStock
            db.MedicinePurchases.Remove(MedicinePurchase);
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
