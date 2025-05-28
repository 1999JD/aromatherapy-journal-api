using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Tag")]
    public class Tag
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Color { get; set; }

        public List<EssentialOilTag> EssentialOils { get; set; } = new List<EssentialOilTag>();
    }
}