using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyLibrary.DBContext
{
    [MetadataType(typeof(FileExtensionMetadata))]
    public partial class FileExtension
    {
        public FileExtension() { }

        [Key, ForeignKey("BookStatus")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }

        public virtual BookStatus BookStatus { get; set; }
    }
}