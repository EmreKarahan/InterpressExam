namespace InterpressExam.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RssItem")]
    public partial class RssItem
    {
        public int Id { get; set; }

        public int RssFileId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Link { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }

        public virtual RssFile RssFile { get; set; }
    }
}
