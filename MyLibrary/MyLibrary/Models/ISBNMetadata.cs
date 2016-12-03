using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.DBContext
{
    //[MetadataType(typeof(ISBNMetadata))]
    //public partial class ISBN
    //{
    //}

    public partial class ISBNMetadata
    {
        [Display(Name = "Edition")]
        public Edition Edition { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "ISBNNumber")]
        public string ISBNNumber { get; set; }

    }
}
