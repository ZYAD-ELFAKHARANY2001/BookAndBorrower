using AutoMapper;
using BookAndBorrower.Application.Contract;
using BookAndBorrower.Dtos.ViewResult;
using BookAndBorrower.DTOs.Book;
using BookAndBorrower.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace BookAndBorrower.Application.Services
{
    public class BookService:IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<BookBorrower> _bookBorrowerRepository;
        private readonly IRepository<Borrower> _borrowerRepository;


        //private readonly LibraryCoontext _libraryContext;
        //private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository, IRepository<BookBorrower> bookBorrowerRepository, IRepository<Borrower> borrowerRepository)
        {
            _bookRepository = bookRepository;
            _bookBorrowerRepository = bookBorrowerRepository;
            _borrowerRepository = borrowerRepository;

        }




        public async Task<ResultDataList<GetAllBooks>> GetAllAsync()
        {
            var books = await Task.FromResult(_bookRepository.GoTo.Select(b => b));
            var bookdtos = books.Select(b => new GetAllBooks()
            {
               Id = b.Id,
               BookName = b.BookName,
               BookImage = b.BookImage,
               NumberOfCopies = b.NumberOfCopies,

            }).ToList();
            ResultDataList<GetAllBooks> result = new ResultDataList<GetAllBooks>();
            result.Entities = bookdtos;
            result.Count = bookdtos.Count;
            return result;
        }
        public async Task<ResultView<GetAllBooks>> BorrowTransact(int id,int borrowerId,string borrowerName)
        {
            var book = await Task.FromResult(_bookRepository.GoTo.FirstOrDefault(b => b.Id == id));
            if (book == null)
            {
                return new ResultView<GetAllBooks>() { Message = "Error: Book not found." };
            }
            var borrower = await Task.FromResult(_borrowerRepository.GoTo.FirstOrDefault(b => b.Id == borrowerId));
            if (borrower == null)
            {
                borrower = new Borrower() { Name = borrowerName };
                //return new ResultView<GetAllBooks>() { Message = "Error: Borrower not found." };
            }
            if (book.BorrowedBooks >= book.NumberOfCopies)
            {
                return new ResultView<GetAllBooks>() { Message = "Error: No copies available for borrowing." };
            }
            //if (book.BorrowedBooks<book.NumberOfCopies)book.BorrowedBooks += 1;
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    book.BorrowedBooks += 1;
                    await _borrowerRepository.DbsetEntitySet.AddAsync(borrower);
                    await _bookBorrowerRepository.DbsetEntitySet.AddAsync(new BookBorrower()
                    {
                        BookId = id,
                        Books = new List<Book> { book },
                        BorrowerId = borrowerId,
                        Borrowers = new List<Borrower> { borrower },
                    });
                    _borrowerRepository.Complete();
                    _bookRepository.Complete();
                    _bookBorrowerRepository.Complete();
                    transaction.Complete();
                    


                    return new ResultView<GetAllBooks>() { IsSuccess=true, Message = "Success: Book borrowed successfully." };
                }
                catch (Exception ex)
                {
                    // Rollback the transaction and return error
                    return new ResultView<GetAllBooks>() { Message = $"Error: {ex.Message}" };
                }
            }
                
        }
        public async Task<ResultView<GetAllBooks>> BorrowBack(int id, int borrowerId, string borrowerName)
        {
            var book = await Task.FromResult(_bookRepository.GoTo.FirstOrDefault(b => b.Id == id));
            if (book == null)
            {
                return new ResultView<GetAllBooks>() { Message = "Error: Book not found." };
            }
            var borrower = await Task.FromResult(_borrowerRepository.GoTo.FirstOrDefault(b => b.Id == borrowerId));
            if (borrower == null)
            {
                //borrower = new Borrower() { Name = borrowerName };
                return new ResultView<GetAllBooks>() { Message = "Error: Borrower not found." };
            }
            var x = _bookBorrowerRepository.DbsetEntitySet.Include(b => b.Borrowers).Include(b => b.Books).Where(b => b.BookId == book.Id && b.BorrowerId == borrower.Id);
            if (book.BorrowedBooks <= 0||!x.Any())
            {
                return new ResultView<GetAllBooks>() { Message = "Error: No copies available for reserviring PLease See again the name of the book." };
            }
            //if (book.BorrowedBooks<book.NumberOfCopies)book.BorrowedBooks += 1;
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    book.BorrowedBooks -= 1;
                   
                    _bookRepository.Complete();
                    transaction.Complete();



                    return new ResultView<GetAllBooks>() { IsSuccess = true, Message = "Success: Book borrowed successfully." };
                }
                catch (Exception ex)
                {
                    // Rollback the transaction and return error
                    return new ResultView<GetAllBooks>() { Message = $"Error: {ex.Message}" };
                }
            }

        }
        //var books = await _bookRepository.GetAllAsync();
        //var bookdtos = books.Select(b => new GetAllBooks()
        //{
        //    Id = b.Id,
        //    Title = b.Title,
        //    Price = b.Price,
        //    PageCount = b.PageCount,
        //    AuthorName = b.Author.Name,
        //    Quntity = b.Quntity
        //}).ToList();


        //ResultDataList<GetAllBooks> result = new ResultDataList<GetAllBooks>();
        //result.Entities = bookdtos;
        //return result;



    }
}
