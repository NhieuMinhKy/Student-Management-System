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
        private readonly MyAppContext _context;
        public TeacherController(MyAppContext context)
        {
            _context = context;
        }

        //READ
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teachers.ToListAsync());
        }

        //CREATE
        [HttpGet]
        public IActionResult Create() //hiển thị form tạo teacher
        {
            return View();
        }

        [HttpPost]
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
        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id","Name","TeacherCode","TeacherStatus")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Update(teacher);
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



