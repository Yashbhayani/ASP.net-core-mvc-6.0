using Microsoft.EntityFrameworkCore;
using WebApp_1.Models;

namespace WebApp_1.Data
{
    public class Applicationclass : DbContext
    {
       public Applicationclass(DbContextOptions<Applicationclass> options) :base(options)
        {
            
        }

        public DbSet<User_Master_Table_1> User_Master_Table_1 { get; set; }
    }
}
