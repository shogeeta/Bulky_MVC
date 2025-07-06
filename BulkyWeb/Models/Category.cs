using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //used for client side data annotations to showfeild values as text tagHelpers
        [DisplayName("Category Name")]
        public string Name { get; set; }
        //used for client side data annotations to showfeild values as text tagHelpers
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }    
    }
}
