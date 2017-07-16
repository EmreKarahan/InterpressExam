namespace InterpressExam.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RssFile")]
    public partial class RssFile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RssFile()
        {
            RssItem = new HashSet<RssItem>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string AtomLink { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(150)]
        public string Link { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(15)]
        public string Language { get; set; }

        public DateTimeOffset? LastUpdateDate { get; set; }

        public int Ttl { get; set; }

        public byte StatusId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RssItem> RssItem { get; set; }
    }
}
