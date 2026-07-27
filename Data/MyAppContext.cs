using StudentManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Data
{
    public class MyAppContext : DbContext //DbContext là lớp cơ sở (có sẵn) của Entity Framework Core, cung cấp các phương thức và thuộc tính để tương tác với cơ sở dữ liệu.
    {
        
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)//constructor nhận vào DbContextOptions<MyAppContext> options, là các tùy chọn cấu hình cho DbContext, ví dụ chuỗi kết nối, provider (SQL Server, SQLite...), v.v.
        {

        }
        public DbSet<Student> Students { get; set; } //DbSet<Item> đại diện cho bảng Items trong cơ sở dữ liệu, nơi bạn có thể thực hiện các thao tác CRUD (Create, Read, Update, Delete) trên các đối tượng Item.
    }
}
