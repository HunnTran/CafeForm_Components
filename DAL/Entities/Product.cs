namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [StringLength(10)]
        public string ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        [StringLength(10)]
        public string CategoryID { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Images { get; set; }

        public virtual Category Category { get; set; }
    }
}
