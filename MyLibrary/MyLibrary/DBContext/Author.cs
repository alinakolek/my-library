using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyLibrary.DBContext
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}