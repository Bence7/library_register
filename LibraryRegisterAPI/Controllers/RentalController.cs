using AutoMapper;
using AutoMapper.Execution;
using LibraryRegisterAPI.Models.Entities;
using LibraryRegisterAPI.Models.Requests;
using LibraryRegisterAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryRegisterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly RentalRepository _repository;
        private readonly IMapper _mapper;

        public RentalController(IEntityRepository<Rental> repository, IMapper mapper)
        {
            _repository = (RentalRepository)repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalRequest>>> Get()
        {
            var rentals = await _repository.GetAll();
            return Ok(rentals);
        }

        [HttpGet("Detailed")]
        public async Task<ActionResult<IEnumerable<RentalRequest>>> GetDetailed()
        {
            var rentals = await _repository.GetDetailed();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentalRequest>> Get(int id)
        {
            var rental = await _repository.Get(id);

            if (rental is null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        [HttpGet("Detailed/{id}")]
        public async Task<ActionResult<RentalRequest>> GetDetailed(int id)
        {
            var rental = await _repository.GetDetailed(id);

            if (rental is null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        [HttpGet("Detailed/BookId/{bookId}")]
        public async Task<ActionResult<RentalRequest>> GetDetailedByBookId(int bookId)
        {
            var rental = await _repository.GetDetailedByBookId(bookId);

            if (rental is null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        [HttpGet("Detailed/MemberId/{memberId}")]
        public async Task<ActionResult<RentalRequest>> GetDetailedAllByMemberId(int memberId)
        {
            var rental = await _repository.GetAllDetailedByMemberId(memberId);

            if (rental is null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingRental = await _repository.Delete(id);

            if (!existingRental)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RentalRequest rental)
        {
            var entity = _mapper.Map<Rental>(rental);

            await _repository.Add(entity);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RentalRequest rental)
        {
            if (id != rental.Id)
            {
                return BadRequest();
            }

            var existingRental = await _repository.Get(id);

            if (existingRental is null)
            {
                return NotFound();
            }

            var entity = _mapper.Map<Rental>(rental);
            await _repository.Update(id, entity);

            return Ok();
        }
    }
}
