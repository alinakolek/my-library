using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyLibrary.DBContext
{
    [MetadataType(typeof(CoverTypeMetadata))]
    public partial class CoverType
    {
        public CoverType() { }

        [Key, ForeignKey("BookStatus")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsHardback { get; set; }

        public virtual BookStatus BookStatus { get; set; }

    }
}