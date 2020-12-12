using APIRestNetCore.Models;
using APIRestNetCore.Swagger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using System.Linq;

namespace APIRestNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        List<Book> books = new List<Book>()
        {
            new Book { Id = 1, Name = "Elantris", Category = "Fantasía", Price = 15 },
            new Book { Id = 2, Name = "La iglesia", Category = "Terror", Price = 10 },
            new Book { Id = 3, Name = "Nigromante", Category = "Fantasía", Price = 20 }
        };

        public BookController()
        {
        }

        /// <summary>
        /// Obtención de los libros de la biblioteca
        /// </summary>
        /// <returns>Listado de libros</returns>
        /// <response code="200">Obtención correcta de los libros</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Book>))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(BooksExample))]
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok(books);
        }

        /// <summary>
        /// Obtención de un libro concreto
        /// </summary>
        /// <param name="id">Identificador del libro que queremos obtener</param>
        /// <returns>Libro que coincide con la busqueda</returns>
        /// <response code="200">Obtención correcta de un libro</response>
        /// <response code="404">Libro no encontrado</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = null)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(BookExample))]
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>
        /// Creación de un nuevo libro, lo añade a la biblioteca
        /// </summary>
        /// <param name="bookModel">Datos del libro a crear</param>
        /// <returns></returns>
        /// <response code="200">Creación correcta de un libro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = null)]
        [SwaggerRequestExample(typeof(Book), typeof(BookExample))]
        [HttpPost]
        public IActionResult Post([FromBody] Book bookModel)
        {
            books.Add(bookModel);

            return Ok();
        }

        /// <summary>
        /// Actualización de un libro de la biblioteca
        /// </summary>
        /// <param name="id">Identificador del libro que queremos modificar</param>
        /// <param name="bookModel">Datos del libro a modificar</param>
        /// <returns></returns>
        /// <response code="200">Actualización correcta de un libro</response>
        /// <response code="400">Parametros de entrada incorrectos</response>
        /// <response code="404">Libro no encontrado</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = null)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = null)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = null)]
        [SwaggerRequestExample(typeof(Book), typeof(BookExample))]
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Book bookModel)
        {
            if (id != bookModel.Id)
            {
                return BadRequest();
            }

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok();
        }

        /// <summary>
        /// Borrado de un libro de la biblioteca
        /// </summary>
        /// <param name="id">Identificador del libro a borrar</param>
        /// <returns></returns>
        /// <response code="200">Borrado de un libro</response>
        /// <response code="404">Libro no encontrado</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = null)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = null)]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book is null)
            {
                return NotFound();
            }

            books.Remove(book);

            return Ok();
        }
    }
}
