using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos
{
    public class EssentialOilDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public string ScientificName { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
        public List<PersonalTagDto> PersonalTags { get; set; } = new List<PersonalTagDto
        >();

    }

    public class UpdateEssentialOilRequestDto
    {

        public string Name { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public string ScientificName { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public List<int> Tags { get; set; } = new List<int>();
        public List<int> PersonalTags { get; set; } = new List<int>();

    }

    public class CreateEssentialOilRequestDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string EnglishName { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public List<int> Tags { get; set; } = new List<int>();
        public List<int> PersonalTags { get; set; } = new List<int>();
    }
}