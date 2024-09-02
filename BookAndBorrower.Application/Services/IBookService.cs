using BookAndBorrower.Application.Contract;
using BookAndBorrower.DTOs.Book;
using BookAndBorrower.Dtos.ViewResult;
using BookAndBorrower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndBorrower.Application.Services
{
    public interface IBookService
    {
        public Task<ResultDataList<GetAllBooks>> GetAllAsync();
        public Task<ResultView<GetAllBooks>> BorrowTransact(int id, int borrowerId, string borrowerName);
        public Task<ResultView<GetAllBooks>> BorrowBack(int id, int borrowerId, string borrowerName);
    }
}
