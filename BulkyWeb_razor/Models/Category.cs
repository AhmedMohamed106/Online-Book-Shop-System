using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb_razor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100 , ErrorMessage ="the input mus be between 1 - 100 ")]
        public int DisplayOrder { get; set; }
    }
}
