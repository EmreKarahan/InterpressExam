namespace InterpressExam.Entity
{
    using System.Data.Entity;

    public partial class RssContext : DbContext
    {
        public RssContext()
            : base("name=RssModel")
        {
        }

        public virtual DbSet<RssFile> RssFile { get; set; }
        public virtual DbSet<RssItem> RssItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<RssItem>()
                .Property(e => e.Link)
                .IsUnicode(false);
        }
    }
}
