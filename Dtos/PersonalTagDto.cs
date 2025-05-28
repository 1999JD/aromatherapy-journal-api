using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos
{
    public class PersonalTagDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Color { get; set; } = string.Empty;
    }

    public class CreatePersonalTagRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class UpdatePersonalTagRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

}