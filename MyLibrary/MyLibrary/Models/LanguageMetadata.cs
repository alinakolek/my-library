using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.DBContext
{
    //[MetadataType(typeof(LanguageMetadata))]
    //public partial class Language
    //{
    //}

    public partial class LanguageMetadata
    {
        [Display(Name = "BookStatus")]
        public BookStatus BookStatus { get; set; }

        [Display(Name = "LanguageList")]
        public LanguageList LanguageList { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "PublicationLanguage")]
        public string PublicationLanguage { get; set; }

        [Display(Name = "OriginalLanguage")]
        public string OriginalLanguage { get; set; }

    }
}
