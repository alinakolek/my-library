using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyLibrary.DBContext
{
    [MetadataType(typeof(LanguageListMetadata))]
    public partial class LanguageList
    {
        public LanguageList()
        {
            Languages = new List<Language>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Language> Languages { get; set; }
    }
}