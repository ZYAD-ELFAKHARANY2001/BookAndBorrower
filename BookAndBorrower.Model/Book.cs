namespace BookAndBorrower.Model
{
    public class Book
    {
        public int Id { get; set; } 
        public string BookName { get; set; }
        public byte[]? BookImage { get; set; }
        public int NumberOfCopies { get; set; }
        public int BorrowedBooks { get; set; } = 0;

    }
}
