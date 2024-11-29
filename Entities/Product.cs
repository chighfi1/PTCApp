using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTCApp.Entities
{
    [Table("Product", Schema = "dbo")]
    public partial class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }

        public DateTime? IntroductionDate { get; set; }

        public decimal? Price { get; set; }

        [Required]
        [MaxLength(500)]
        public string Url { get; set; }

        public int? CategoryId { get; set; }
    }
}
