using System.Data.Entity;
using System.Diagnostics;

namespace ORM
{
    public class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
            Debug.WriteLine("Context creating!");
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<CompletedTest> CompletedTests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public new void Dispose()
        {
            base.Dispose();
            Debug.WriteLine("Context disposing!");
        }
    }
}
