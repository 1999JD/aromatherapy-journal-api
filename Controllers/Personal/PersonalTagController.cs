using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Dtos;
using Microsoft.AspNetCore.Identity;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using api.Mappers;
using api.Extensions;
using System.Security.Claims;

namespace api.Controllers
{
    [Route("api/personal/tag")]
    [ApiController]
    public class PersonalTagController : ControllerBase
    {
        private readonly IPersonalTagRepository _personalTagRepo;
        private readonly UserManager<AppUser> _userManager;

        private readonly ApplicationDbContext _context;

        public PersonalTagController(ApplicationDbContext context, IPersonalTagRepository personalTagRepo, UserManager<AppUser> userManager)
        {
            _personalTagRepo = personalTagRepo;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return NotFound();
            }
            var personalTags = await _personalTagRepo.GetAllAsync(appUser.Id);
            var personalTagDto = personalTags.Select(x => x.ToPersonalTagDto()).ToList();
            return Ok(personalTagDto);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return NotFound();
            }
            var personalTag = await _personalTagRepo.GetByIdAsync(id, appUser.Id);
            if (personalTag == null)
            {
                return NotFound();
            }

            return Ok(personalTag.ToPersonalTagDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePersonalTagRequestDto personalTagDto)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return Unauthorized();
            }
            var personalTag = personalTagDto.ToPersonalTagFromCreateDto();
            personalTag.AppUserId = appUser.Id;

            await _personalTagRepo.CreateAsync(personalTag);
            return CreatedAtAction(nameof(GetById), new { id = personalTag.Id }, personalTag.ToPersonalTagDto());
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePersonalTagRequestDto tagDto)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return Unauthorized();
            }

            var tag = await _personalTagRepo.UpdateAsync(id, tagDto, appUser.Id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag.ToPersonalTagDto());
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return Unauthorized();
            }
            var tag = await _personalTagRepo.DeleteAsync(id, appUser.Id);
            if (tag == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}