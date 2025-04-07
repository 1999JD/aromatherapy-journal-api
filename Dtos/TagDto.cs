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


}