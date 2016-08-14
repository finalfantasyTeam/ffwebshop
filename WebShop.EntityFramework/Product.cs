//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.InvoiceDetails = new HashSet<InvoiceDetail>();
            this.OrderDetails = new HashSet<OrderDetail>();
            this.ProductMetas = new HashSet<ProductMeta>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<decimal> OriginPrice { get; set; }
        public Nullable<decimal> SellPrice { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> ManufactoryId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> ImportDate { get; set; }
        public string FeatureImage { get; set; }
        public string ImageList { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<decimal> Discount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ProductBranch ProductBranch { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductStatu ProductStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductMeta> ProductMetas { get; set; }
    }
}
