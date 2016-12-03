using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.DBContext
{
    //[MetadataType(typeof(FileExtensionMetadata))]
    //public partial class FileExtension
    //{
    //}

    public partial class FileExtensionMetadata
    {
        [Display(Name = "BookStatus")]
        public BookStatus BookStatus { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

    }
}
