using AsynEntityFrameworkExample.Services;
using Microsoft.AspNetCore.Mvc;
using AsynEntityFrameworkExample.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AsynEntityFrameworkExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService service;

        public BookController(IBookService service)
        {
            this.service = service;
        }
        // GET: api/<BookController>
        [HttpGet]
        [Route("Getbooks")]
        public IActionResult Get()
        {
            try
            {
                var model = service.GetBooks();
                return new ObjectResult(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        // GET api/<BookController>/5

        [HttpGet]
        [Route("GetBookById/{id}")]
       
        public IActionResult Get(int id)
        {
            try
            {
                var model = service.GetBookById(id);
                if (model != null)
                    return new ObjectResult(model);
                else
                    return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
        }

        // POST api/<BookController>
        [HttpPost]
        [Route("AddBook")]
        public  async Task<IActionResult> Post([FromBody] Book book)
        {
            try
            {
                int result = await service.AddBook(book);
                if(result>=1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }

        }

        // PUT api/<BookController>/5
        [HttpPut]
        [Route("UpdateBook")]
        public async Task<IActionResult> Put( [FromBody] Book book)
        {
            try
            {
                int result = await service.UpdateBook(book);
                if( result>=1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete]
        [Route("DeleteBook/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                int result = await service.DeleteBook(id);
                if(result>=1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
