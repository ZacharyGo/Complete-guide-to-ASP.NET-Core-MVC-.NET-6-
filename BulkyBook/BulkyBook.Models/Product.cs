using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required] 
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string  ISBN { get; set; }
        [Required]
        public string  Author { get; set; }
        [Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price50 { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price100 { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; } // Since Class is same as name it will auotmatically create a foreign relationshipm this indicate a navigation property to the Category class since CategoryId is same as CAtegory with Id. If it was not Id like CategoryTest then need annotation of [ForeignKey("CategoryTest")]
        [Required]
        public int CoverTypeId { get; set; }
        public CoverType CoverType { get; set; }
    }
}
