using Microsoft.EntityFrameworkCore;

namespace RestWithASPNETUdemy.Model.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext()
        {
        
        }
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) {}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
