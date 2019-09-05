using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmazonDream.Entities
{
    [Table("PRODUCT")]
    public class Product
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }

        [Required]
        public long ProductPrice { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        public int ProductDiscount { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductCategory { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductSubCategory { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductBrand { get; set; }

        [Required]
        public string ProductGenderType { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductDescription { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProductStatus { get; set; }



        [ForeignKey("Seller")]
        public long Seller_ID { get; set; }
        public virtual Seller Seller { get; set; }




        public virtual ICollection<ProductPicture> ProductPictures { get; set; }


    }
}
