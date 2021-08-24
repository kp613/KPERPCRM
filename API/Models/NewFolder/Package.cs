using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models.ProductModels
{
    public enum UnitOfWeight
    {
        kg,g,l,ml
    }
    public class Package
    {
        public int Id { get; set; }

        [Display(Name = "规格编号")]    //用三位数101-999表示，以便于交流
        public int SpecificationNumber { get; set; }

        [Display(Name= "包装名称")]
        public string Name { get; set; }

        [Display(Name = "包装物重量")]
        public float WeightOfPackage { get; set; }

        [Display(Name="每包装单位净重")]
        public float WeightOfProduct { get; set; }

        [Display(Name = "包装单位")]
        public UnitOfWeight UnitOfWeight { get; set; }

        [Display(Name = "包装描述")]
        public string Description { get; set; }

        public ICollection<Inventory> Inventories { get; set; }
    }
}
