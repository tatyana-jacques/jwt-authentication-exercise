using Microsoft.EntityFrameworkCore;
using RH.Models;

namespace RH.Context
{
    public class RhContext: DbContext
    {
        public RhContext(DbContextOptions<RhContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
       
    }
}
