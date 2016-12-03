using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyLibrary.DBContext
{
    [MetadataType(typeof(DescriptionMetadata))]
    public partial class Description
    {
        public Description() { }

        [Key, ForeignKey("Book")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DescriptionContent { get; set; }

        public virtual Book Book { get; set; }
    }
}