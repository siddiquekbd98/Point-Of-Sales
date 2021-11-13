//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicineProjects.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Medicine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicine()
        {
            this.MedicineStocks = new HashSet<MedicineStock>();
            this.MedicinePurchases = new HashSet<MedicinePurchase>();
            this.MedicineSales = new HashSet<MedicineSale>();
        }
    
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public Nullable<int> MedicineCategoryId { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public string Status { get; set; }
        public string ImagePath { get; set; }
    
        public virtual TblMedicineCategory TblMedicineCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicineStock> MedicineStocks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicinePurchase> MedicinePurchases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicineSale> MedicineSales { get; set; }
    }
}
