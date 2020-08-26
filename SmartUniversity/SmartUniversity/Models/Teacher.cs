using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartUniversity.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "You must have provide a name")]
        [Display(Name = "Teacher Name")]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must have provide a contact no")]
        [Display(Name = "Contact No")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string ContactNo { get; set; }

        [Display(Name = "Designation")]
        public int DesignationId { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public double CreditToBeTaken { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

    }
}