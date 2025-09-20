using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;
using api.Dtos;
using api.Helpers;

namespace api.Repository
{
    public class TagRepository : ITagRepository
    {
        private const int DefaultPageSize = 10;
        private readonly ApplicationDbContext _context;

        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Tag>> GetAllAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }

            if (pageSize <= 0)
            {
                pageSize = DefaultPageSize;
            }

            var query = _context.Tags.AsNoTracking().OrderBy(tag => tag.Id);
            var totalCount = await query.CountAsync();

            var tags = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Tag>
            {
                Items = tags,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            return await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag> CreateAsync(Tag tagModel)
        {
            await _context.Tags.AddAsync(tagModel);
            await _context.SaveChangesAsync();
            return tagModel;
        }

        public async Task<Tag> UpdateAsync(int id, UpdateTagRequestDto tagDto)
        {
            var exisingTag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);
            if (exisingTag == null)
            {
                return null;
            }

            exisingTag.Name = tagDto.Name;
            await _context.SaveChangesAsync();
            return exisingTag;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exisingTag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);
            if (exisingTag == null)
            {
                return false;
            }

            _context.Tags.Remove(exisingTag);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
