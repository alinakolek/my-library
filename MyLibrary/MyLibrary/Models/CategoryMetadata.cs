using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.DBContext
{
    //[MetadataType(typeof(CategoryMetadata))]
    //public partial class Category
    //{
    //}

    public partial class CategoryMetadata
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
