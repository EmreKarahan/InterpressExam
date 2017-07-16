namespace InterpressExam.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RssFile")]
    public partial class RssFile
    {
       
        public RssFile()
        {
         
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


    }
}
