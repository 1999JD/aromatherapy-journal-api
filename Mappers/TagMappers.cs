using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

using api.Dtos;

namespace api.Mappers
{
    public static class TagMappers
    {
        public static TagDto ToTagDto(this Tag tagModel)
        {
            return new TagDto
            {
                Id = tagModel.Id,
                Name = tagModel.Name,
                Color = tagModel.Color,
            };
        }

        public static Tag ToTagFromCreateDto(this CreateTagRequestDto tagDto)
        {
            return new Tag
            {
                Name = tagDto.Name,
                Color = tagDto.Color,
            };
        }
    }
}