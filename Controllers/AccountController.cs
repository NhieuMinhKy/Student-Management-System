using StudentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
namespace StudentManagementSystem.Controllers
{
    public class AccountController : Controller
    {

        // 1. Hàm hiển thị form (chạy khi user gõ URL truy cập trang login)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // 2. Hàm nhận dữ liệu (chạy khi user bấm nút Đăng nhập)
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            Console.WriteLine(model.Password);
            // ModelState.IsValid kiểm tra xem dữ liệu gửi lên có thỏa mãn các luật [Required] bên Model chưa
            if (ModelState.IsValid)
            {
                //Dữ liệu từ View lúc này đã được gán tự động vào biến 'model'
                string submittedUser = model.StudentIdOrEmail;
                string submittedPass = model.Password;

                //Tại đây bạn viết logic kết nối Database, so sánh mật khẩu, tạo token...

                 //Nếu thành công, chuyển hướng về trang chủ
                return RedirectToAction("Index", "Student");
            }

            // Nếu dữ liệu bị lỗi (ví dụ để trống user), trả lại đúng giao diện Login kèm theo những gì user vừa nhập để họ sửa
            return View(model);
        }
    }
}
