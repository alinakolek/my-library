using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyLibrary.DBContext
{
    public class Edition
    {
        public Edition()
        {
            PublishingHouses = new List<PublishingHouse>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime PublicationDate { get; set; }
        public string PublicationPlace { get; set; }
        public string PublicationIssueNumber { get; set; }

        public virtual BookStatus BookStatus { get; set; }
        public virtual ICollection<PublishingHouse> PublishingHouses { get; set; }
        public virtual ISBN ISBN { get; set; }
    }
}