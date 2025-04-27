using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos;
using api.Mappers;

namespace api.Mappers
{
    public static class PersonalTagMappers
    {
        public static PersonalTagDto ToPersonalTagDto(this PersonalTag personalTagModel)
        {
            return new PersonalTagDto
            {
                Id = personalTagModel.Id,
                Name = personalTagModel.Name

            };

        }

        public static PersonalTag ToPersonalTagFromCreateDto(this CreatePersonalTagRequestDto personalTag)
        {
            return new PersonalTag
            {
                Name = personalTag.Name,

            };
        }
    }

}