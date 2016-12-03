using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyLibrary.DBContext
{
    [MetadataType(typeof(BookStatusMetadata))]
    public partial class BookStatus
    {
        public BookStatus() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsMissing { get; set; }
        public string UserName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
        public virtual Edition Edition { get; set; }
        public virtual Language Language { get; set; }
        public virtual CoverType CoverType { get; set; }
        public virtual FileExtension FileExtension { get; set; }
    }
}