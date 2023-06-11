using AutoMapper;
using LibraryRegisterAPI.Models.Entities;
using LibraryRegisterAPI.Models.Requests;
using LibraryRegisterAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryRegisterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly MemberRepository _repository;
        private readonly IMapper _mapper;

        public MemberController(IEntityRepository<Member> repository, IMapper mapper)
        {
            _repository = (MemberRepository)repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberRequest>>> Get()
        {
            var members = await _repository.GetAll();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberRequest>> Get(int id)
        {
            var member = await _repository.Get(id);

            if (member is null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        [HttpGet("Name/{name}")]
        public async Task<ActionResult<MemberRequest>> GetByName(string name)
        {
            var member = await _repository.FindByName(name);

            if (member is null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        [HttpDelete("{id}")]
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
        public async Task<IActionResult> Post([FromBody] MemberRequest member)
        {
            var entity = _mapper.Map<Member>(member);

            await _repository.Add(entity);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MemberRequest member)
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

            var entity = _mapper.Map<Member>(member);
            await _repository.Update(id, entity);

            return Ok();
        }
    }
}
