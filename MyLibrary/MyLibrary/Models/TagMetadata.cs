using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.DBContext
{
    //[MetadataType(typeof(TagMetadata))]
    //public partial class Tag
    //{
    //}

    public partial class TagMetadata
    {
        [Display(Name = "Book")]
        public Book Book { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

    }
}
