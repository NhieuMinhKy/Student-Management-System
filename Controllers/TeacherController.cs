using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System.Threading.Channels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Net.WebRequestMethods;

namespace StudentManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private readonly MyAppContext _context; //biến đại diện cho Dbcontext của Entity Framework Core, giúp controller link với Database (chỉ được gán giá trị 1 lần duy nhất và chỉ dùng bên trong class TeacherCtroller.cs)
        public TeacherController(MyAppContext context)
        {
            _context = context;
        }

        //READ
        public async Task<IActionResult> Index() //naming fucntion trùng với file Index.cshtml trong view để thư viện tự link giữa controller với view (Convention over Configuration (Ưu tiên quy ước hơn cấu hình) của Framework using Microsoft.EntityFrameworkCore;)
        {
            return View(await _context.Teachers.ToListAsync());
        }

        /*CREATE
        [HttpGet]
        public IActionResult Create() //hiển thị form tạo teacher
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name","Id","TeacherCode")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Teacher");
            }
            return View(teacher);
        }

        //EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            return View(teacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id","Name","TeacherCode","TeacherStatus")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Teacher");
            }
            return View(teacher);
        }*/

        //Create+Edit
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id =0)
        {
            if (id == 0) 
            {
                return View(new Teacher());
            }

            var teacher = await _context.Teachers.FindAsync(id);
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([Bind("TeacherId", "FullName", "TeacherCode", "Status", "DepartmentId")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                if (teacher.TeacherId == 0)
                {
                    _context.Teachers.Add(teacher);
                }
                else
                {
                    _context.Teachers.Update(teacher);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Teacher");
            }
            return View(teacher);
        }

        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if(teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Teacher");
        }
        
    }
}



