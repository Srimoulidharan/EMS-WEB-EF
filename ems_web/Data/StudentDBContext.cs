using Ems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ems_web.Models.Data
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options):base(options) 
        {

        }
        public DbSet<EMS> Employee {  get; set; }

        
    }
}
