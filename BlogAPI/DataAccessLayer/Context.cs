using Microsoft.EntityFrameworkCore;

namespace BlogAPI.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=302-08;Database=Db_BlogCoreAPI;User=WebMobile_302;Password=WebMobile.302;");

        }
        public DbSet<Employee> Employees { get; set; }  
    }
}
