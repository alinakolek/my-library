using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyLibrary.DBContext
{
    [MetadataType(typeof(ISBNMetadata))]
    public partial class ISBN
    {
        public ISBN() { }

        [Key, ForeignKey("Edition")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ISBNNumber { get; set; }

        public virtual Edition Edition { get; set; }
    }
}