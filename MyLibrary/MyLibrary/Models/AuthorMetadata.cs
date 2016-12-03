using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.DBContext
{
    //[MetadataType(typeof(AuthorMetadata))]
    //public partial class Author
    //{
    //}

    public partial class AuthorMetadata
    {
        [Display(Name = "Books")]
        public Book Books { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Forename")]
        public string Forename { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

    }
}
