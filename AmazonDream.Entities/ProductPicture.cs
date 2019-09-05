﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmazonDream.Entities
{
    [Table("PRODUCTPICTURE")]
    public class ProductPicture
    {
        [Key]
        public long ID { get; set; }

        [Required]
        public string PicturePath { get; set; }


        [ForeignKey("Product")]
        public long Product_ID { get; set; }
        public virtual Product Product { get; set; }
    }
}
