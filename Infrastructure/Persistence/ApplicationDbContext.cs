using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PostsAPI.Domain.Entities;
using PostsAPI.Infrastructure.Identity;
using PostsAPI.Infrastructure.Persistence.Config;
using System.Threading;
using System.Threading.Tasks;

namespace PostsAPI.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Post>(new PostConfig());

            base.OnModelCreating(builder);
        }

        public DbSet<Post> Posts { get; set; }
    }
}
