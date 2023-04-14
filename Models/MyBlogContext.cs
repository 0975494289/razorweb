using Microsoft.EntityFrameworkCore;
//using MySql.EntityFrameworkCore;
//using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
namespace entity.models
{
    public class MyBlogContext : DbContext
    {
        public MyBlogContext(DbContextOptions<MyBlogContext> options):base(options) //Chết đau đớn, chỉ vì chỗ này đặt là protected thay vì public mà mất cả đêm tìm hiểu
        {
        }
        public DbSet<Article> articles {set;get;}
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}