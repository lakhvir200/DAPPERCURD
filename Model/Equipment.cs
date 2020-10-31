using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCurd.Model
{
    public class Equipments
    {
        [Key]
        public int EquipmentID { get; set; }
        public string EquipmentCode { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public int MaintPerodicityID { get; set; }
        public int UnitLookupID { get; set; }
        public string Specifications { get; set; }
        public int DepartmentID { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public decimal CostOfEquipment { get; set; }
        public int SupplierID { get; set; }
        public int StatusID { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public string CreatedBy { get; set; }
        public DateTime UpdatedBy { get; set; }
        public string CategoryName { get; set; }
    }
}
