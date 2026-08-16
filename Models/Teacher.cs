using System.ComponentModel.DataAnnotations; // Thư viện cung cấp các thuộc tính để xác thực dữ liệu và hiển thị thông tin trong mô hình dữ liệu.
namespace StudentManagementSystem.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập TeacherCode")]
        [Display(Name = "TeacherCode")]
        [MaxLength(20)]
        public string TeacherCode { get; set; } = string.Empty;

        [Required (ErrorMessage = "Vui lòng nhập FullName")]
        [Display(Name = "FullName")]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Phone number")]
        [Phone(ErrorMessage = "Phone number không hợp lệ")]
        [MaxLength(20)]
        public string? Phone { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [MaxLength(100)]
        public string? Email { get; set; }

        [Display(Name ="DepartmentId")]
        [Required(ErrorMessage = "Vui lòng chọn DepartmentId")]
        public int DepartmentId { get; set; }

        [Display(Name = "Teacher Status")]
        [MaxLength(20)]
        public string Status { get; set; } = "Active";
    }
}
     