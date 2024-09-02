using BookAndBorrower.Application.Services;
using BookAndBorrower.Dtos.Book;
using BookAndBorrower.DTOs.Book;
using Microsoft.AspNetCore.Mvc;

namespace BookAndBorrower.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();
            var res = books.Entities.ToList();
            return View(res);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Borrow(int bookId)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var res = await _bookService.BorrowTransact(bookId, 1, "Zyad");
        //            if (res.IsSuccess)
        //            {
        //                return RedirectToAction(nameof(Index));

        //            }
        //            else
        //            {
        //                ViewBag.Error = res.Message;
        //                return View(res);
        //            }

        //        }
        //        else
        //        {
        //            return View();

        //        }
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        [HttpPost]
        public async Task<JsonResult> Borrow(int bookId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _bookService.BorrowTransact(bookId, 1, "Zyad");
                    if (res.IsSuccess)
                    {
                        return Json(new { isSuccess = true });
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = res.Message });
                    }
                }
                else
                {
                    return Json(new { isSuccess = false, message = "Invalid data." });
                }
            }
            catch
            {
                return Json(new { isSuccess = false, message = "An error occurred." });
            }
        }  
        [HttpPost]
        public async Task<JsonResult> BorrowBack(int bookId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _bookService.BorrowBack(bookId, 1, "Zyad");
                    if (res.IsSuccess)
                    {
                        return Json(new { isSuccess = true });
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = res.Message });
                    }
                }
                else
                {
                    return Json(new { isSuccess = false, message = "Invalid data." });
                }
            }
            catch
            {
                return Json(new { isSuccess = false, message = "An error occurred." });
            }
        }

    }
}
