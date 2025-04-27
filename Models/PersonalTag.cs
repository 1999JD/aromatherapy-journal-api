using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("PersonalTag")]
    public class PersonalTag
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        // 外鍵
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }

}