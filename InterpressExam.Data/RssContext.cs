using System.Data.Entity;
using InterpressExam.Entity;

namespace InterpressExam.Data
{
    public partial class RssContext : DbContext
    {
        public RssContext()
            : base("name=RssModel")
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<RssFile> RssFile { get; set; }
        public virtual DbSet<RssItem> RssItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<RssFile>()
                .Property(e => e.AtomLink)
                .IsUnicode(false);

            modelBuilder.Entity<RssFile>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<RssFile>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<RssFile>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<RssFile>()
                .HasMany(e => e.RssItem)
                .WithRequired(e => e.RssFile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RssItem>()
                .Property(e => e.Link)
                .IsUnicode(false);
        }
    }
}
