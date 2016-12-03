using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.DBContext
{
    //[MetadataType(typeof(LanguageListMetadata))]
    //public partial class LanguageList
    //{
    //}

    public partial class LanguageListMetadata
    {
        [Display(Name = "Languages")]
        public Language Languages { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

    }
}
