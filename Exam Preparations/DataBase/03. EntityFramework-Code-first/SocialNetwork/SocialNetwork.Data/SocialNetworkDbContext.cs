using SocialNetwork.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SocialNetwork.Data
{
    public class SocialNetworkDbContext :DbContext
    {
        public SocialNetworkDbContext()
            :base("SocialNetwork")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<Friendship> Friendship { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }

    
}
