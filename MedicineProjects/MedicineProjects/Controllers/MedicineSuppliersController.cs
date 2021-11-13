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
   
    public class MedicineSuppliersController : Controller
    {
        private MedicineSalesEntities db = new MedicineSalesEntities();

        // GET: MedicineSuppliers
        public ActionResult Index()
        {
            return View(db.MedicineSuppliers.ToList());
        }

        // GET: MedicineSuppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineSupplier medicineSupplier = db.MedicineSuppliers.Find(id);
            if (medicineSupplier == null)
            {
                return HttpNotFound();
            }
            return View(medicineSupplier);
        }

        // GET: MedicineSuppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicineSuppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicineSupplierId,MedicineSupplierName,Mobile,Address,ManagerName")] MedicineSupplier medicineSupplier)
        {
            if (ModelState.IsValid)
            {
                db.MedicineSuppliers.Add(medicineSupplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicineSupplier);
        }

        // GET: MedicineSuppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineSupplier medicineSupplier = db.MedicineSuppliers.Find(id);
            if (medicineSupplier == null)
            {
                return HttpNotFound();
            }
            return View(medicineSupplier);
        }

        // POST: MedicineSuppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicineSupplierId,MedicineSupplierName,Mobile,Address,ManagerName")] MedicineSupplier medicineSupplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicineSupplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicineSupplier);
        }

        // GET: MedicineSuppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineSupplier medicineSupplier = db.MedicineSuppliers.Find(id);
            if (medicineSupplier == null)
            {
                return HttpNotFound();
            }
            return View(medicineSupplier);
        }

        // POST: MedicineSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicineSupplier medicineSupplier = db.MedicineSuppliers.Find(id);
            db.MedicineSuppliers.Remove(medicineSupplier);
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
