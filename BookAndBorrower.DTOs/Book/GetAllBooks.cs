using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndBorrower.DTOs.Book
{
    public class GetAllBooks
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public byte[]? BookImage { get; set; }
        public int NumberOfCopies { get; set; }
        public int BorrowedBooks { get; set; } = 0;
    }
}
