using System.ComponentModel.DataAnnotations;

namespace UserProject.Model
{

    public class User
    {
        [Key]
        public int Id { get; set; }

        //Name data validation
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        //Email data validation
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}
