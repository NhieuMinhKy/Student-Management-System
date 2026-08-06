using System.ComponentModel.DataAnnotations; // Thư viện cung cấp các thuộc tính để xác thực dữ liệu và hiển thị thông tin trong mô hình dữ liệu.
namespace StudentManagementSystem.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Vui lòng nhập tên giáo viên")]
        [Display(Name = "Tên giáo viên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mã giáo viên")]
        [Display (Name = "Mã giáo viên")]
        public string TeacherCode { get; set; }

        [Display(Name = "Trạng thái giáo viên")]
        public string TeacherStatus { get; set; } = "Active";
    }
}
     