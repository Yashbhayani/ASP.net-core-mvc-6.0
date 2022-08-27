using System.ComponentModel.DataAnnotations;

namespace WebApp_1.Models
{
    public class User_Master_Table_1
    {
        [Key]
        public int User_MasterID { get; set; }


        [Display(Name = "First Name : ")]
        public string User_MasterFName { get; set; }

        [Display(Name = "Second Name : ")]
        [Required(ErrorMessage = "Required")]
        public string User_MasterSName { get; set; }


        [Display(Name = "Email : ")]
        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string User_MasterEmail { get; set; }

        [Display(Name = "Mobile No : ")]
        [Required(ErrorMessage = "Required")]
        [MinLength(10, ErrorMessage = "Mobile Number Not Should be 11 digit!")]
        [MaxLength(10, ErrorMessage = "Mobile Number Not Should be 11 digit!")]
        public string User_Master_MO_BO { get; set; }
    }
}
