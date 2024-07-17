using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOfWork.Core.Interfaces;
using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.Core.Repositories;

namespace RepositoryPatternWithUnitOfWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
           _unitOfWork =unitOfWork;
        }
        [HttpGet("GetById")]
       

        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Authors.GetById(1));
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_unitOfWork.Authors.Find(b=>b.Name=="Mostafa Yehya" ));

        }
    }
}
