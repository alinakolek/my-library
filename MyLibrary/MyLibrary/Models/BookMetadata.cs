using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.DBContext
{
    //[MetadataType(typeof(BooksMetadata))]
    //public partial class Books
    //{
    //}

    public partial class BookMetadata
    {
        [Display(Name = "Author")]
        public Author Author { get; set; }

        [Display(Name = "BookStatuses")]
        public BookStatus BookStatuses { get; set; }

        [Display(Name = "Category")]
        public Category Category { get; set; }

        [Display(Name = "Description")]
        public Description Description { get; set; }

        [Display(Name = "Tags")]
        public Tag Tags { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "PageNumber")]
        public int PageNumber { get; set; }

        [Display(Name = "BookCoverImage")]
        public byte[] BookCoverImage { get; set; }

    }
}
