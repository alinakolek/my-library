using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.DBContext
{
    //[MetadataType(typeof(BookStatusMetadata))]
    //public partial class BookStatus
    //{
    //}

    public partial class BookStatusMetadata
    {
        [Display(Name = "Book")]
        public Book Book { get; set; }

        [Display(Name = "CoverType")]
        public CoverType CoverType { get; set; }

        [Display(Name = "Edition")]
        public Edition Edition { get; set; }

        [Display(Name = "FileExtension")]
        public FileExtension FileExtension { get; set; }

        [Display(Name = "Language")]
        public Language Language { get; set; }

        [Display(Name = "User")]
        public User User { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "IsAvailable")]
        public bool IsAvailable { get; set; }

        [Display(Name = "IsMissing")]
        public bool IsMissing { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }

    }
}
