using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("EssentialOil")]
    public class EssentialOil
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string EnglishName { get; set; } = string.Empty;
        [Required]
        public string ScientificName { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public List<EssentialOilTag> Tags { get; set; } = new List<EssentialOilTag>();
        public List<EssentialOilPersonalTag> PersonalTags { get; set; } = new List<EssentialOilPersonalTag
        >();
    }
}