using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos;

namespace api.Mappers
{
    public static class EssentialOilMappers
    {
        public static EssentialOilDto ToEssentialOilDto(this EssentialOil essentialOilModel)
        {
            return new EssentialOilDto
            {
                Id = essentialOilModel.Id,
                Note = essentialOilModel.Note,
                Tags = essentialOilModel.Tags,
                PersonalTags = essentialOilModel.PersonalTags
            };

        }
        
        public static EssentialOil ToEssentialOilFromCreateDto(this CreateEssentialOilRequestDto essentialOilDto)
        {
            return new EssentialOil
            {
                Note = essentialOilDto.Note,
                Tags = essentialOilDto.Tags,
                PersonalTags = essentialOilDto.PersonalTags
            };

        }
    }
}