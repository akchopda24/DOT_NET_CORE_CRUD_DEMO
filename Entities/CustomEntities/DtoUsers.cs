using CRUDDemo.Entities.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDDemo.Entities.CustomEntities
{
    public class DtoUsers
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DateValidation]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
    }
}
