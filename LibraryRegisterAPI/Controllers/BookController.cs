using LibraryRegisterAPI.Models;
using LibraryEntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using LibraryRegisterAPI.Repositories;

namespace LibraryEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IEntityRepository<Book> _repository;

        public BookController(IEntityRepository<Book> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var books = await _repository.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _repository.Get(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingBook = await _repository.Delete(id);

            if (!existingBook)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            await _repository.Add(book);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var existingBook = await _repository.Get(id);

            if (existingBook is null)
            {
                return NotFound();
            }

            await _repository.Update(id, book);

            return Ok();
        }
    }
}
