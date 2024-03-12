//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sample2_WindowsFormsApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Product
    {
        [ReadOnly(true)]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProductNumber { get; set; }
        [Required]
        public bool MakeFlag { get; set; }
        [Required]
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        [Required, Range(1, Int16.MaxValue)]
        public short SafetyStockLevel { get; set; } = 1;
        [Required, Range(1, Int16.MaxValue)]
        public short ReorderPoint { get; set; } = 1;
        [Required]
        public decimal StandardCost { get; set; }
        [Required]
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public int DaysToManufacture { get; set; } = 1;
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public Nullable<int> ProductSubcategoryID { get; set; }
        public Nullable<int> ProductModelID { get; set; }
        [Required]
        public System.DateTime SellStartDate { get; set; } = DateTime.Now;
        public Nullable<System.DateTime> SellEndDate { get; set; }
        public Nullable<System.DateTime> DiscontinuedDate { get; set; }
        [Required]
        public System.Guid rowguid { get; set; } = Guid.NewGuid();
        [Required]
        public System.DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
