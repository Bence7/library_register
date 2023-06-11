using LibraryRegisterAPI.Models.Requests;
using LibraryEntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using LibraryRegisterAPI.Repositories;
using LibraryRegisterAPI.Models.Entities;
using AutoMapper;

namespace LibraryEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookRepository _repository;
        private readonly IMapper _mapper;

        public BookController(IEntityRepository<Book> repository, IMapper mapper)
        {
            _repository = (BookRepository)repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookRequest>>> Get()
        {
            var books = await _repository.GetAll();
            return Ok(books);
        }

        [HttpGet("Available")]
        public async Task<ActionResult<IEnumerable<BookRequest>>> GetAvailables()
        {
            var books = await _repository.GetAvailable();
            return Ok(books);
        }

        [HttpGet("Unavailable")]
        public async Task<ActionResult<IEnumerable<BookRequest>>> GetUnavailable()
        {
            var books = await _repository.GetUnavailable();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookRequest>> Get(int id)
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
        public async Task<IActionResult> Post([FromBody] BookRequest book)
        {
            var entity = _mapper.Map<Book>(book);

            await _repository.Add(entity);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] BookRequest book)
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

            var entity = _mapper.Map<Book>(book);
            await _repository.Update(id, entity);

            return Ok();
        }
    }
}
