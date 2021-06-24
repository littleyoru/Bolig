namespace Residences
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BoligContext : DbContext
    {
        public BoligContext()
            : base("name=BoligContext")
        {
        }

        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<PostCode> PostCodes { get; set; }
        public virtual DbSet<Residence> Residences { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Residence>()
              .HasRequired(t => t.User)
              .WithMany()
              .Map(m => m.MapKey("UserId"));

            modelBuilder.Entity<Residence>()
                .HasRequired(t => t.PostCode)
                .WithMany()
                .Map(m => m.MapKey("PostCodeId"));

            modelBuilder.Entity<Login>()
                .HasRequired(t => t.User)
                .WithMany()
                .Map(m => m.MapKey("UserId"));

            //modelBuilder.Entity<User>()
            //    .HasMany(t => t.UserResidences)
            //    .WithRequired();
        }
    }
}
