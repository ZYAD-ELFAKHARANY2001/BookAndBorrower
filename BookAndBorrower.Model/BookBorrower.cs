using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndBorrower.Model
{
    public class BookBorrower
    {
        [Key]
        public int Code { get; set; }
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public ICollection<Book> Books { get; set;}

        [ForeignKey(nameof(Borrower))]
        public int BorrowerId { get; set; }
        public ICollection<Borrower> Borrowers { get; set;}
    }
}
