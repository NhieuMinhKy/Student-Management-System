using System.ComponentModel.DataAnnotations;
namespace StudentManagementSystem.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập MSSV hoặc Email")]
        [Display(Name = "Student Id / Email")]
        public string StudentIdOrEmail { get; set; }
 
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //thuộc tính để phân biệt vai trò đăng nhập
        public string Role { get; set; }
    }
}
