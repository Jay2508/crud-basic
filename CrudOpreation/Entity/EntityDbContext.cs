using Microsoft.EntityFrameworkCore;
using CrudOpreation.Entity.Model;

namespace CrudOpreation.Entity
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions options) : base(options) {  


        }
        public  DbSet<RegisterTbl> RegisterTbls { get; set; }   
    }
}
