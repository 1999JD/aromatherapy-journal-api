using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos;
using api.Mappers;

namespace api.Mappers
{
    public static class EssentialOilMappers
    {
        public static EssentialOilDto ToEssentialOilDto(this EssentialOil essentialOilModel)
        {
            return new EssentialOilDto
            {
                Id = essentialOilModel.Id,
                Name = essentialOilModel.Name,
                EnglishName = essentialOilModel.EnglishName,
                ScientificName = essentialOilModel.ScientificName,
                Note = essentialOilModel.Note,
                Tags = essentialOilModel.Tags.Select(x =>
                {
                    return new TagDto
                    {
                        Id = x.Tag.Id,
                        Name = x.Tag.Name,
                        Color = x.Tag.Color
                    };
                }).ToList(),
                PersonalTags = essentialOilModel.PersonalTags.Select(x =>
                {
                    return new PersonalTagDto
                    {
                        Id = x.PersonalTag.Id,
                        Name = x.PersonalTag.Name,
                        Color = x.PersonalTag.Color
                    };
                }).ToList()
            };

        }

        public static EssentialOil ToEssentialOilFromCreateDto(this CreateEssentialOilRequestDto essentialOilDto)
        {
            return new EssentialOil
            {
                Note = essentialOilDto.Note,
                Name = essentialOilDto.Name,
                EnglishName = essentialOilDto.EnglishName,
                Tags = essentialOilDto.Tags.Select(x =>
                 {
                     return new EssentialOilTag
                     {
                         TagId = x,
                     };
                 }).ToList()
            };
            // PersonalTags = essentialOilDto.PersonalTags
        }
    }

}