using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.DBContext
{
    //[MetadataType(typeof(UserMetadata))]
    //public partial class User
    //{
    //}

    public partial class UserMetadata
    {
        [Display(Name = "BookStatus")]
        public BookStatus BookStatus { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Forename")]
        public string Forename { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

    }
}
