using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public BookController(ApplicationDbContext applicationDb)
        {
            _applicationDbContext = applicationDb;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _applicationDbContext.Book.ToList() });
        }
    }
}
