using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndBorrower.Dtos.Book
{
    public class CreateOrUpdateBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quntity { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
    }
}
