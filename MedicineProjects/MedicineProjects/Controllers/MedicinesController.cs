using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicineProjects.Filters;
using MedicineProjects.Models;
using MedicineProjects.ViewModel;

namespace MedicineProjects.Controllers
{
	[TestActionFilter]

	public class MedicinesController : Controller
	{
		public ActionResult Index(int? id)
		{
			var ctx = new MedicineSalesEntities();

			var categoryWiseMedicineQty = from m in ctx.Medicines
										  group m by m.MedicineCategoryId into g
										  select new
										  {
											  g.FirstOrDefault().MedicineCategoryId
											  //Qty = g.Sum(s => s.Quantity)
										  };
			var listCategory = (from c in ctx.TblMedicineCategories
								join cwpq in categoryWiseMedicineQty on c.MedicineCategoryId equals cwpq.MedicineCategoryId
								select new VmCategory
								{
									categoryName = c.MedicineCategoryName,
									categoryID = (int)cwpq.MedicineCategoryId
									//Quantity = cwpq.Qty
								}).ToList();
			var listMedicine = (from m in ctx.Medicines
								join c in ctx.TblMedicineCategories on m.MedicineCategoryId equals c.MedicineCategoryId
								where m.MedicineCategoryId == id
								select new VmMedicine
								{
									categoryID = (int)m.MedicineCategoryId,
									categoryName = c.MedicineCategoryName,
									ImagePath = m.ImagePath,
									SalePrice = (decimal)m.SalePrice,
									MedicineId = m.MedicineId,
									MedicineName = m.MedicineName,
									Status = m.Status
								}).ToList();

			var oCategoryWiseMedicine = new VmCategoryWiseMedicine();
			oCategoryWiseMedicine.CategoryList = listCategory;
			oCategoryWiseMedicine.MedicineList = listMedicine;
			oCategoryWiseMedicine.categoryID = listMedicine.Count > 0 ? listMedicine[0].categoryID : 0;
			oCategoryWiseMedicine.categoryName = listMedicine.Count > 0 ? listMedicine[0].categoryName : "";

			return View(oCategoryWiseMedicine);
		}

		public ActionResult Create()
		{
			var model = new VmMedicineCategory();
			var ctx = new MedicineSalesEntities();
			model.CategoryList = ctx.TblMedicineCategories.ToList();
			return View(model);
		}

		[HttpPost]
		public ActionResult Create(TblMedicineCategory model, string[] MedicineName, decimal[] SalePrice, string[] Status, HttpPostedFileBase[] imgFile)
		{
			var ctx = new MedicineSalesEntities();
			var oCatetory = (from c in ctx.TblMedicineCategories where c.MedicineCategoryName == model.MedicineCategoryName.Trim() select c).FirstOrDefault();
			if (oCatetory == null)
			{
				ctx.TblMedicineCategories.Add(model);
				ctx.SaveChanges();
			}
			else
			{
				model.MedicineCategoryId = oCatetory.MedicineCategoryId;
			}

			var listMedicine = new List<Medicine>();
			for (int i = 0; i < MedicineName.Length; i++)
			{
				string imgPath = "";
				if (imgFile[i] != null && imgFile[i].ContentLength > 0)
				{
					var fileName = Path.GetFileName(imgFile[i].FileName);
					string fileLocation = Path.Combine(
						Server.MapPath("~/uploads"), fileName);
					imgFile[i].SaveAs(fileLocation);

					imgPath = "/uploads/" + imgFile[i].FileName;
				}

				var newMedicine = new Medicine();
				newMedicine.MedicineName = MedicineName[i];
				newMedicine.SalePrice = (int?)SalePrice[i];
				newMedicine.ImagePath = imgPath;
				newMedicine.Status = Status[i];
				newMedicine.MedicineCategoryId = model.MedicineCategoryId;
				listMedicine.Add(newMedicine);
			}
			ctx.Medicines.AddRange(listMedicine);
			ctx.SaveChanges();

			return RedirectToAction("Index");
		}
		public ActionResult Edit(int id)
		{
			var ctx = new MedicineSalesEntities();
			var oMedicine = (from m in ctx.Medicines
							 join c in ctx.TblMedicineCategories on m.MedicineCategoryId equals c.MedicineCategoryId
							 where m.MedicineCategoryId == id
							 select new VmMedicine
							 {
								 categoryID = (int)m.MedicineCategoryId,
								 categoryName = c.MedicineCategoryName,
								 ImagePath = m.ImagePath,
								 SalePrice = (decimal)m.SalePrice,
								 MedicineId = m.MedicineId,
								 MedicineName = m.MedicineName,
								 Status = m.Status
							 }).FirstOrDefault();
			oMedicine.CategoryList = ctx.TblMedicineCategories.ToList();
			return View(oMedicine);
		}

		[HttpPost]
		public ActionResult Edit(VmMedicine model)
		{
			var ctx = new MedicineSalesEntities();

			string imgPath = "";
			if (model.ImgFile != null && model.ImgFile.ContentLength > 0)
			{
				var fileName = Path.GetFileName(model.ImgFile.FileName);
				string fileLocation = Path.Combine(
					Server.MapPath("~/uploads"), fileName);
				model.ImgFile.SaveAs(fileLocation);

				imgPath = "/uploads/" + model.ImgFile.FileName;
			}

			var oMedicine = ctx.Medicines.Where(w => w.MedicineId == model.MedicineId).FirstOrDefault();
			if (oMedicine != null)
			{
				oMedicine.MedicineName = model.MedicineName;
				oMedicine.SalePrice = model.SalePrice;
				oMedicine.MedicineCategoryId = model.categoryID;
				if (!string.IsNullOrEmpty(imgPath))
				{
					var fileName = Path.GetFileName(oMedicine.ImagePath);
					string fileLocation = Path.Combine(Server.MapPath("~/uploads"), fileName);
					if (System.IO.File.Exists(fileLocation))
					{
						System.IO.File.Delete(fileLocation);
					}
				}
				oMedicine.ImagePath = imgPath == "" ? oMedicine.ImagePath : imgPath;

				ctx.SaveChanges();
			}

			return RedirectToAction("Index");
		}

		public ActionResult EditMultiple(int id)
		{
			var ctx = new MedicineSalesEntities();
			var oCategoryWiseMedicine = new VmCategoryWiseMedicine();
			var listMedicine = (from m in ctx.Medicines
								join c in ctx.TblMedicineCategories on m.MedicineCategoryId equals c.MedicineCategoryId
								where m.MedicineCategoryId == id
								select new VmMedicine
								{
									categoryID = (int)m.MedicineCategoryId,
									categoryName = c.MedicineCategoryName,
									ImagePath = m.ImagePath,
									SalePrice = (decimal)m.SalePrice,
									MedicineId = m.MedicineId,
									MedicineName = m.MedicineName,
									Status = m.Status
								}).ToList();
			oCategoryWiseMedicine.MedicineList = listMedicine;

			oCategoryWiseMedicine.CategoryList = (from c in ctx.TblMedicineCategories
												  select new VmCategory
												  {
													  categoryID = c.MedicineCategoryId,
													  categoryName = c.MedicineCategoryName
												  }).ToList();
			oCategoryWiseMedicine.categoryID = listMedicine.Count > 0 ? listMedicine[0].categoryID : 0;
			oCategoryWiseMedicine.categoryName = listMedicine.Count > 0 ? listMedicine[0].categoryName : "";
			return View(oCategoryWiseMedicine);
		}

		[HttpPost]
		public ActionResult EditMultiple(TblMedicineCategory model, int[] MedicineId, string[] MedicineName, decimal[] SalePrice, string[] Status, HttpPostedFileBase[] imgFile)
		{
			var ctx = new MedicineSalesEntities();
			var listMedicine = new List<Medicine>();
			for (int i = 0; i < MedicineName.Length; i++)
			{
				if (MedicineId[i] > 0)
				{
					string imgPath = "";
					if (imgFile[i] != null && imgFile[i].ContentLength > 0)
					{
						var fileName = Path.GetFileName(imgFile[i].FileName);
						string fileLocation = Path.Combine(
							Server.MapPath("~/uploads"), fileName);
						imgFile[i].SaveAs(fileLocation);

						imgPath = "/uploads/" + imgFile[i].FileName;
					}
					int pid = MedicineId[i];
					var oMedicine = ctx.Medicines.Where(w => w.MedicineId == pid).FirstOrDefault();
					if (oMedicine != null)
					{
						oMedicine.MedicineName = MedicineName[i];
						oMedicine.SalePrice = SalePrice[i];
						oMedicine.Status = Status[i];
						oMedicine.MedicineCategoryId = model.MedicineCategoryId;
						if (!string.IsNullOrEmpty(imgPath))
						{
							var fileName = Path.GetFileName(oMedicine.ImagePath);
							string fileLocation = Path.Combine(Server.MapPath("~/uploads"), fileName);
							if (System.IO.File.Exists(fileLocation))
							{
								System.IO.File.Delete(fileLocation);
							}
						}
						oMedicine.ImagePath = imgPath == "" ? oMedicine.ImagePath : imgPath;
						ctx.SaveChanges();
					}
				}
				else if (!string.IsNullOrEmpty(MedicineName[i]))
				{
					string imgPath = "";
					if (imgFile[i] != null && imgFile[i].ContentLength > 0)
					{
						var fileName = Path.GetFileName(imgFile[i].FileName);
						string fileLocation = Path.Combine(
							Server.MapPath("~/uploads"), fileName);
						imgFile[i].SaveAs(fileLocation);

						imgPath = "/uploads/" + imgFile[i].FileName;
					}

					var newMedicine = new Medicine();
					newMedicine.MedicineName = MedicineName[i];
					newMedicine.SalePrice = SalePrice[i];
					newMedicine.ImagePath = imgPath;
					newMedicine.Status = Status[i];
					newMedicine.MedicineCategoryId = model.MedicineCategoryId;
					ctx.Medicines.Add(newMedicine);
					ctx.SaveChanges();
				}
			}

			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			var ctx = new MedicineSalesEntities();
			var oMedicine = ctx.Medicines.Where(p => p.MedicineId == id).FirstOrDefault();
			if (oMedicine != null)
			{
				ctx.Medicines.Remove(oMedicine);
				ctx.SaveChanges();

				var fileName = Path.GetFileName(oMedicine.ImagePath);
				string fileLocation = Path.Combine(
					Server.MapPath("~/uploads"), fileName);

				if (System.IO.File.Exists(fileLocation))
				{

					System.IO.File.Delete(fileLocation);
				}
			}

			return RedirectToAction("Index");
		}

		public ActionResult DeleteMultiple(int id)
		{
			var ctx = new MedicineSalesEntities();
			var listMedicine = ctx.Medicines.Where(m => m.MedicineCategoryId == id).ToList();
			foreach (var oMedicine in listMedicine)
			{
				if (oMedicine != null)
				{
					ctx.Medicines.Remove(oMedicine);
					ctx.SaveChanges();

					var fileName = Path.GetFileName(oMedicine.ImagePath);
					string fileLocation = Path.Combine(
						Server.MapPath("~/uploads"), fileName);
					if (System.IO.File.Exists(fileLocation))
					{

						System.IO.File.Delete(fileLocation);
					}
				}
			}

			var oCategory = ctx.TblMedicineCategories.Where(c => c.MedicineCategoryId == id).FirstOrDefault();
			ctx.TblMedicineCategories.Remove(oCategory);
			ctx.SaveChanges();

			return RedirectToAction("Index");
		}

	}
}
