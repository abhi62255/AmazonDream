﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonDream.ViewModels
{
    public class ProductModel
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Maximum length is 200")]
        public string ProductName { get; set; }

        [Required]
        public long ProductPrice { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        public int ProductDiscount { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Maximum length is 100")]
        public string ProductCategory { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Maximum length is 100")]
        public string ProductSubCategory { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Maximum length is 100")]
        public string ProductBrand { get; set; }

        [Required]
        public string ProductGenderType { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Maximum length is 100")]
        public string ProductDescription { get; set; }

        public long Seller_ID { get; set; }

    }
}
