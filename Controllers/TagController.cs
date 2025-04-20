using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/tag")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagRepository _tagRepo;

        private readonly ApplicationDbContext _context;

        public TagController(ApplicationDbContext context, ITagRepository tagRepo)
        {
            _tagRepo = tagRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _tagRepo.GetAllAsync();
            var tagDto = tags.Select(x => x.ToTagDto()).ToList();
            return Ok(tagDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var tag = await _tagRepo.GetByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag.ToTagDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagRequestDto tagDto)
        {
            var tag = tagDto.ToTagFromCreateDto();
            await _tagRepo.CreateAsync(tag);
            return CreatedAtAction(nameof(GetById), new { id = tag.Id }, tag.ToTagDto());

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTagRequestDto tagDto)
        {
            var tag = await _tagRepo.UpdateAsync(id, tagDto);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag.ToTagDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tag = await _tagRepo.DeleteAsync(id);
            if (tag == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}