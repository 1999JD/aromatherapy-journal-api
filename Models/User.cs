using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }

        public List<EssentialOil> essentialOils { get; set; } = new List<EssentialOil>();
        public List<PersonalTag> personalTags { get; set; } = new List<PersonalTag>();
        public List<PersonalNote> PersonalNotes { get; set; } = new List<PersonalNote>();  // 使用者的所有個人筆記

    }
}