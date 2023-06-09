using LibraryRegisterAPI.Models;
using LibraryRegisterAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryRegisterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        IEntityRepository<Member> _repository;

        public MemberController(IEntityRepository<Member> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> Get()
        {
            var members = await _repository.GetAll();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> Get(int id)
        {
            var member = await _repository.Get(id);

            if (member is null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingMember = await _repository.Delete(id);

            if (!existingMember)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Member member)
        {
            await _repository.Add(member);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            var existingMember = await _repository.Get(id);

            if (existingMember is null)
            {
                return NotFound();
            }

            await _repository.Update(id, member);

            return Ok();
        }
    }
}
