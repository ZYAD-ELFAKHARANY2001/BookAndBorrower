using BookAndBorrower.Model;
using Microsoft.EntityFrameworkCore;

namespace BookAndBorrower.Context
{
    public class LibraryContext: DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Borrower> Borrowers { get; set; }
        public virtual DbSet<BookBorrower> BookBorrower { get; set; }
        public LibraryContext(DbContextOptions dbContextOptions):base(dbContextOptions) { }
    }
}
