using MedicineProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicineProjects.ViewModel
{
    public class VmMedicine
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int categoryID { get; set; }
        public decimal SalePrice { get; set; }
        public string ImagePath { get; set; }
        public string Status { get; set; }
        public string categoryName { get; set; }
        public HttpPostedFileBase ImgFile { get; set; }
        public List<TblMedicineCategory> CategoryList { get; set; }

    }
}