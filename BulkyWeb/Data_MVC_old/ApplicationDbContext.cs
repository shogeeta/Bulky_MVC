//using BulkyWeb.Models;
//using Microsoft.EntityFrameworkCore;

//namespace BulkyWeb.Data
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
//        {
               
//        }
//        //create tables in entity framework
//        public DbSet<Category> Categories { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//            //seed data
//            modelBuilder.Entity<Category>().HasData(
//                 new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
//                 new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
//                 new Category { Id = 3, Name = "History", DisplayOrder = 3 }
//                );
//        }
//    }
//}
