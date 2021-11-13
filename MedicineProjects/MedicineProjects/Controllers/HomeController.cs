using MedicineProjects.Libs.Utilities;
using MedicineProjects.Models;
using MedicineProjects.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MedicineProjects.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			DashboardViewModel dashboard = new DashboardViewModel();

			dashboard.customer_count = db.Customers.Count();
			dashboard.medicine_count = db.Medicines.Count();
			dashboard.medicineSupplier_count = db.MedicineSuppliers.Count();
			dashboard.salePoint_count = db.TblSalePoints.Count();
			dashboard.medicinePurchase_count = db.MedicinePurchases.Count();
			dashboard.medicineSales_count = db.MedicineSales.Count();
			dashboard.medicineStock_count = db.MedicineStocks.Count();

			return View(dashboard);
		}




		#region Login
		private MedicineSalesEntities db = new MedicineSalesEntities();
		public ActionResult Login()
		{
			return View();
		}

		//POST: HomeController/Login
	   [HttpPost]
	   [ValidateAntiForgeryToken]
		public ActionResult Login([Bind(Include = "Username,UserPass")] TblUser model)
		{
			try
			{
				var oTblUser = db.TblUsers.Where(o => o.Username == model.Username && o.UserPass == model.UserPass).FirstOrDefault();
				if (oTblUser != null)
				{
					var listTblUserRole = db.TblUserRoles.Where(o => o.UserID == oTblUser.UserID).ToList();
					Session["TblUsers"] = oTblUser;
					Session["TblUserRoles"] = listTblUserRole;
					if (oTblUser.UserType == UserType.SuperAdmin.ToString())
					{
						return RedirectToAction("Index", "Users");
					}
					else if (oTblUser.UserType == UserType.GeneralUser.ToString())
					{
						return RedirectToAction("Index", "SalePoints");
					}
				}

				return View();
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Logout()
		{
			Session.Remove("TblUsers");
			return RedirectToAction("Index", "Home");
		}
		#endregion

	}
}