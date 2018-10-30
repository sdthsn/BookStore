
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestDB
{
    [Table("BookStores")]
    public class Bookstore
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string AuthorName { get; set; }

        [Required]
        [StringLength(255)]
        public string PublisherName { get; set; }
    }
}
