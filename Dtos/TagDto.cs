using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos
{
    public class TagDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public class CreateTagRequestDto
    {
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateTagRequestDto
    {
        public string Name { get; set; } = string.Empty;
    }

}