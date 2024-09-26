using Lc_userapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Lc_userapi.Data
{
    public class Appdbcontext:DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options): base(options) { }

        public DbSet<userClass> userClasses { get; set; } 
    }
}
