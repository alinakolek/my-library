using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyLibrary.DBContext
{
    public class Book
    {
        public Book()
        {
            Tags = new List<Tag>();
            BookStatuses = new List<BookStatus>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageNumber { get; set; }
        public byte[] BookCoverImage { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual Description Description { get; set; }
        public virtual ICollection<BookStatus> BookStatuses { get; set; }
    }
}