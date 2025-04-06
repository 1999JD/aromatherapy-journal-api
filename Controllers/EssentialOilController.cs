using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Mappers;
using api.Dtos;
using api.Models;

namespace api.Controllers
{
    [Route("api/essential-oil")]
    [ApiController]
    public class EssentialOilController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IEssentialOilRepository _essentialOilRepo;

        public EssentialOilController(ApplicationDbContext context, IEssentialOilRepository essentialOilRepo)
        {
            _essentialOilRepo = essentialOilRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var essentialOils = await _essentialOilRepo.GetAllAsync();

            var essentialOilDto = essentialOils.Select(x => x.ToEssentialOilDto()).ToList();
            return Ok(essentialOilDto);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var essentialOil = await _essentialOilRepo.GetByIdAsync(id);
            if (essentialOil == null)
            {
                return NotFound();
            }

            return Ok(essentialOil.ToEssentialOilDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEssentialOilRequestDto essentialOilDto)
        {
            var essentialOil = essentialOilDto.ToEssentialOilFromCreateDto();
            await _essentialOilRepo.CreateAsync(essentialOil);
            return CreatedAtAction(nameof(GetById), new { id = essentialOil.Id }, essentialOil.ToEssentialOilDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEssentialOilRequestDto essentialOilDto)
        {
            var essentialOil = await _essentialOilRepo.UpdateAsync(id, essentialOilDto);
            if (essentialOil == null)
            {
                return NotFound();
            }
            return Ok(essentialOil.ToEssentialOilDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var essentialOil = await _essentialOilRepo.DeleteAsync(id);
            if (essentialOil == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("{id:int}/image")]
        public async Task<IActionResult> UploadImage()
        {
            throw new Exception("Not implemented yet");
        }

    }


}