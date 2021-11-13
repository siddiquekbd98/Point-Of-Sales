using MedicineProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicineProjects.ViewModel
{
	public class VmMedicineCategory
	{
		public int categoryID { get; set; }
		public string categoryName { get; set; }
		public List<TblMedicineCategory> CategoryList { get; set; }
		public List<VmMedicine> MedicineList { get; set; }

	}
}