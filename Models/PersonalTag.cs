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
        [ForeignKey("User")]
        public int UserId { get; set; }  // 外鍵
        public User User { get; set; }  // 導覽屬性

    }

}