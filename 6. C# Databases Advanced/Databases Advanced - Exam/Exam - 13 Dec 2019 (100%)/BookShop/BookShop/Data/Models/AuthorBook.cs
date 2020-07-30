using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Data.Models
{
    public class AuthorBook
    {

        //TODO: Composite key
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
