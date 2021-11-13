using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MedicineProjects.Filters;
using MedicineProjects.Models;

namespace MedicineProjects.Controllers
{
    [TestActionFilter]
    public class MedicineCategoriesController : Controller
    {
        private MedicineSalesEntities db = new MedicineSalesEntities();

        // GET: MedicineCategories
        public async Task<ActionResult> Index()
        {
            return View(await db.TblMedicineCategories.ToListAsync());
        }

        // GET: MedicineCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMedicineCategory tblMedicineCategory = await db.TblMedicineCategories.FindAsync(id);
            if (tblMedicineCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblMedicineCategory);
        }

        // GET: MedicineCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicineCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MedicineCategoryId,MedicineCategoryName")] TblMedicineCategory tblMedicineCategory)
        {
            if (ModelState.IsValid)
            {
                var medicineCategoryId = db.TblMedicineCategories.Max(o => (int?)o.MedicineCategoryId) ?? 0;
                var oTblMedicineCategory = new TblMedicineCategory();
                oTblMedicineCategory.MedicineCategoryId = medicineCategoryId + 1;
                oTblMedicineCategory.MedicineCategoryName = tblMedicineCategory.MedicineCategoryName;
                db.TblMedicineCategories.Add(oTblMedicineCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblMedicineCategory);
        }

        // GET: MedicineCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMedicineCategory tblMedicineCategory = await db.TblMedicineCategories.FindAsync(id);
            if (tblMedicineCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblMedicineCategory);
        }

        // POST: MedicineCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MedicineCategoryId,MedicineCategoryName")] TblMedicineCategory tblMedicineCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMedicineCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblMedicineCategory);
        }

        // GET: MedicineCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMedicineCategory tblMedicineCategory = await db.TblMedicineCategories.FindAsync(id);
            if (tblMedicineCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblMedicineCategory);
        }

        // POST: MedicineCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TblMedicineCategory tblMedicineCategory = await db.TblMedicineCategories.FindAsync(id);
            db.TblMedicineCategories.Remove(tblMedicineCategory);
            await db.SaveChangesAsync();
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
