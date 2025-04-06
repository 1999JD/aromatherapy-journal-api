using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos
{
    public class EssentialOilDto
    {
        public int Id { get; set; }
        public string Note { get; set; } = string.Empty;
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<PersonalTag> PersonalTags { get; set; } = new List<PersonalTag
        >();

    }

    public class UpdateEssentialOilRequestDto
    {
        public string Note { get; set; } = string.Empty;
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<PersonalTag> PersonalTags { get; set; } = new List<PersonalTag>();

    }

    public class CreateEssentialOilRequestDto
    {
        public string Note { get; set; } = string.Empty;
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<PersonalTag> PersonalTags { get; set; } = new List<PersonalTag>();
    }
}