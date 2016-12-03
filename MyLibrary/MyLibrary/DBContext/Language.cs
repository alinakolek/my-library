using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyLibrary.DBContext
{
    [MetadataType(typeof(LanguageMetadata))]
    public partial class Language
    {
        public Language() { }

        [Key, ForeignKey("BookStatus")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PublicationLanguage { get; set; }
        public string OriginalLanguage { get; set; }

        public virtual LanguageList LanguageList { get; set; }
        public virtual BookStatus BookStatus { get; set; }
    }
}