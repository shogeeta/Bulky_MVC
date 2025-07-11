using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWebRazor_Temp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //used for client side data annotations to showfeild values as text tagHelpers
        [DisplayName("Category Name")]
        //used for valdiations to showfeild values as text using tagHelpers and to display custom error messages
        [MaxLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        public string Name { get; set; }
        //used for client side data annotations to showfeild values as text tagHelpers
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1-100.")]
        public int DisplayOrder { get; set; }
    }
}
