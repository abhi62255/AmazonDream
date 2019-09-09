﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmazonDream.Entities
{
    [Table("PLACEDORDER")]
    public class PlacedOrder
    {
        [Key]
        public long ID { get; set; }

        public long OrderNumber { get; set; }

        public int Quantity { get; set; }

        public long Amount { get; set; }

        public DateTime DateTime { get; set; }

        public string PaymentType { get; set; }

        public string Status { get; set; }
        public string Address { get; set; }



        [ForeignKey("Product")]
        public long Product_ID { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Customer")]
        public long Customer_ID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
