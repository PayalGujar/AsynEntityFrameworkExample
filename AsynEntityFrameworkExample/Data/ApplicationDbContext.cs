using AsynEntityFrameworkExample.Models;
using Microsoft.EntityFrameworkCore;
namespace AsynEntityFrameworkExample.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
