using APIRestNetCore.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace APIRestNetCore.Swagger
{
    public class BookExample : IExamplesProvider<Book>
    {
        public Book GetExamples()
        {
            return new Book()
            {
                Id = 1,
                Name = "Elantris",
                Category = "Fantasía",
                Price = 15
            };
        }
    }

    public class BooksExample : IExamplesProvider<IEnumerable<Book>>
    {
        public IEnumerable<Book> GetExamples()
        {
            return new List<Book>
            {
                new Book() 
                { 
                    Id = 1, 
                    Name = "Elantris", 
                    Category = "Fantasía", 
                    Price = 15 
                }
            };
        }
    }
}
