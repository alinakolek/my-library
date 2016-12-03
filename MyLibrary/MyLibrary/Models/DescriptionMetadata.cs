using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.DBContext
{
    //[MetadataType(typeof(DescriptionMetadata))]
    //public partial class Description
    //{
    //}

    public partial class DescriptionMetadata
    {
        [Display(Name = "Book")]
        public Book Book { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "DescriptionContent")]
        public string DescriptionContent { get; set; }

    }
}
