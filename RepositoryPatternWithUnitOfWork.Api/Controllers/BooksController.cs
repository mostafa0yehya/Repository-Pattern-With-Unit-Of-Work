using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOfWork.Core.Consts;
using RepositoryPatternWithUnitOfWork.Core.Interfaces;
using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.Core.Repositories;
using RepositoryPatternWithUnitOfWork.EF.Repositories;

namespace RepositoryPatternWithUnitOfWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_unitOfWork.Books.Find(b => b.Title == "How To be Your Self", new[] {"Author"}));

        }
        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("How"),null,null,o=>o.Id,orderbydirection:OrderBy.Descending));

        }
        [HttpPost("AddOne")]
        public IActionResult Add()
        {
           
            return Ok(_unitOfWork.Books.Add(new Book { Title="new book",AuthorId=2}));
        }
    }
}
