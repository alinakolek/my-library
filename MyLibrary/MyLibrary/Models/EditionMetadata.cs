using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.DBContext
{
    //[MetadataType(typeof(EditionMetadata))]
    //public partial class Edition
    //{
    //}

    public partial class EditionMetadata
    {
        [Display(Name = "BookStatus")]
        public BookStatus BookStatus { get; set; }

        [Display(Name = "ISBN")]
        public ISBN ISBN { get; set; }

        [Display(Name = "PublishingHouses")]
        public PublishingHouse PublishingHouses { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "PublicationDate")]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "PublicationPlace")]
        public string PublicationPlace { get; set; }

        [Display(Name = "PublicationIssueNumber")]
        public string PublicationIssueNumber { get; set; }

    }
}
