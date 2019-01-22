using Ith.Domain.Entities;
using System.Data.Entity;

namespace Ith.Domain.Concrete
{
    class PostDbContext : DbContext
    {
        public PostDbContext() : base("name=PostDbContext") { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
