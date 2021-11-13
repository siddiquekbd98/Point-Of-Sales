using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicineProjects.ViewModel
{
	public class VmCategoryWiseMedicine
	{
		public int categoryID { get; set; }
		public string categoryName { get; set; }
		public List<VmCategory> CategoryList { get; set; }
		public List<VmMedicine> MedicineList { get; set; }

	}
}