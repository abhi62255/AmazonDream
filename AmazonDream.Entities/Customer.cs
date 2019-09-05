using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmazonDream.Entities
{
    [Table("CUSTOMER")]
    public class Customer
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(70)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        public string Gender { get; set; }

    }
}
