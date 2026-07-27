using System.ComponentModel.DataAnnotations;
namespace StudentManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên sinh viên")]
        [Display(Name = "Tên sinh viên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mã sinh viên")]
        [Display(Name = "Mã sinh viên")]
        public string StudentCode { get; set; }

        public String StudentStatus { get; set; } = "Active"; // Active, Inactive
    }
}
