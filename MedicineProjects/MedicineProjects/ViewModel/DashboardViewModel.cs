using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicineProjects.ViewModel
{
	public class DashboardViewModel
	{
		public int customer_count { get; set; }
		public int medicine_count { get; set; }
		public int medicineSupplier_count { get; set; }
		public int salePoint_count { get; set; }
		public int medicinePurchase_count { get; set; }
		public int medicineSales_count { get; set; }
		public int medicineStock_count { get; set; }
	}
}