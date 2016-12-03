using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.DBContext
{
    //[MetadataType(typeof(PublishingHouseMetadata))]
    //public partial class PublishingHouse
    //{
    //}

    public partial class PublishingHouseMetadata
    {
        [Display(Name = "Editions")]
        public Edition Editions { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

    }
}
