using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {

        private readonly MyAppContext _context; //khai báo một biến _context kiểu MyAppContext, dùng để truy cập cơ sở dữ liệu thông qua Entity Framework Core.
        public StudentController(MyAppContext context)  //constructor nhận vào MyAppContext context, là một đối tượng DbContext được cấu hình để kết nối với cơ sở dữ liệu của ứng dụng.
        {
            _context = context;
        }
        public async Task<IActionResult> Index() //async Task<IActionResult> Index() là một phương thức bất đồng bộ (asynchronous) trả về một IActionResult, đại diện cho kết quả của một hành động trong ASP.NET Core MVC. Phương thức này được sử dụng để xử lý yêu cầu HTTP và trả về dữ liệu hoặc giao diện người dùng.
        {
            var student =await _context.Students.ToListAsync(); //Students là table name, await là đợi khi query xong hết list thì chạy tiếp
            return View(student);
        }

        //CREATE
        /*[HttpGet] //để hiển thị form tạo mới sinh viên
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //để xử lý dữ liệu từ form gửi lên và lưu vào cơ sở dữ liệu
        public async Task<IActionResult> Create([Bind("Id,StudentCode,Name,StudentStatus")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync(); // await: trong lúc chạy insert hay update databse thì CPU xử lý vc khác () cho đến khi SQL báo lưu thành công thì quay lại
                return RedirectToAction("Index", "Student");
            }
            return View(student);
        }


        //EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x=>x.Id == id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentCode,Name","StudentStatus")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Student");
            }
            return View(student);
        }*/


        //CreateOrEdit
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id = 0) {
            if (id == 0)
            {
                return View(new Student());
            }
            return View(await _context.Students.FindAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(int id, Student student)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Students.Add(student);
                }
                else
                {
                    _context.Students.Update(student);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Student");
            }
            return View(student);
        }


        //DELETE
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            return View(item);
        }

        [HttpPost ,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
            
        }
    }
}
