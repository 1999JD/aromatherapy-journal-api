using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("EssentialOil")]
    public class EssentialOil
    {
        public int Id { get; set; }
        public string Note { get; set; } = string.Empty;
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<PersonalTag> PersonalTags { get; set; } = new List<PersonalTag
        >();
    }
}