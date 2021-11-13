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
    public class SalePointsController : Controller
    {
        private MedicineSalesEntities db = new MedicineSalesEntities();

        // GET: SalePoints
        public async Task<ActionResult> Index()
        {
            return View(await db.TblSalePoints.ToListAsync());
        }

        // GET: SalePoints/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblSalePoint tblSalePoint = await db.TblSalePoints.FindAsync(id);
            if (tblSalePoint == null)
            {
                return HttpNotFound();
            }
            return View(tblSalePoint);
        }

        // GET: SalePoints/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalePoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SalePointID,SalePointNo,SalePointName,SalePointManager,Address")] TblSalePoint tblSalePoint)
        {
            if (ModelState.IsValid)
            {
                var salePointId = db.TblSalePoints.Max(o => (int?)o.SalePointID) ?? 0;
                var oTblSalePoint = new TblSalePoint();
                oTblSalePoint.SalePointID = salePointId + 1;
                oTblSalePoint.SalePointNo = tblSalePoint.SalePointNo;
                oTblSalePoint.SalePointName = tblSalePoint.SalePointName;
                oTblSalePoint.SalePointManager = tblSalePoint.SalePointManager;
                oTblSalePoint.Address = tblSalePoint.Address;
                db.TblSalePoints.Add(oTblSalePoint);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblSalePoint);
        }

        // GET: SalePoints/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblSalePoint tblSalePoint = await db.TblSalePoints.FindAsync(id);
            if (tblSalePoint == null)
            {
                return HttpNotFound();
            }
            return View(tblSalePoint);
        }

        // POST: SalePoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SalePointID,SalePointNo,SalePointName,SalePointManager,Address")] TblSalePoint tblSalePoint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSalePoint).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblSalePoint);
        }

        // GET: SalePoints/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblSalePoint tblSalePoint = await db.TblSalePoints.FindAsync(id);
            if (tblSalePoint == null)
            {
                return HttpNotFound();
            }
            return View(tblSalePoint);
        }

        // POST: SalePoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TblSalePoint tblSalePoint = await db.TblSalePoints.FindAsync(id);
            db.TblSalePoints.Remove(tblSalePoint);
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
