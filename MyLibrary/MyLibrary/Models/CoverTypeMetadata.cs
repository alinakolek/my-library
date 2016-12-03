using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.DBContext
{
    //[MetadataType(typeof(CoverTypeMetadata))]
    //public partial class CoverType
    //{
    //}

    public partial class CoverTypeMetadata
    {
        [Display(Name = "BookStatus")]
        public BookStatus BookStatus { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "IsHardback")]
        public bool IsHardback { get; set; }

    }
}
