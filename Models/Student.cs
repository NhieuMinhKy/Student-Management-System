using System.ComponentModel.DataAnnotations;
namespace StudentManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mã sinh viên")]
        [Display(Name = "StudentCode")]
        [MaxLength (20, ErrorMessage = "Student Code không vượt quá 20 ký tự")]
        public string StudentCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập Student FirstName")]
        [Display(Name = "FirstName")]
        [MaxLength (50)]
        public string FirstName { get; set; } = string.Empty;

        [Required (ErrorMessage = "Student FirstName")]
        [Display(Name = "LastName")]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Display (Name ="Date of birth")]
        public DateOnly? DateOfBirth { get; set; }

        [Display (Name ="Gender")]
        [MaxLength(10)]
        public string? Gender { get; set; }

        [Display (Name ="Phone number")]
        [Phone(ErrorMessage = "Phone number không hợp lệ")]
        [MaxLength(20)]
        public string? Phone { get; set; }

        [Display (Name ="Email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [MaxLength(100)]
        public string? Email { get; set; }

        [Display (Name ="Address")]
        [MaxLength(255)]
        public string? Address { get; set; }

        [Display(Name = "Status")]
        [MaxLength(20)]
        public String? Status { get; set; } = "Active"; // Active, Inactive

        [Display(Name = "Create date")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
