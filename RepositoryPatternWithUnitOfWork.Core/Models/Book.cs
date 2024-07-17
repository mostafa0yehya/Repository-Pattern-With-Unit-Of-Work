using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; } = null!;
       public Author? Author { get; set; }
        public int AuthorId { get; set; }
    }
}
