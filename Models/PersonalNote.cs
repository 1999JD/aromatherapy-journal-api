using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("PersonalNote")]
    public class PersonalNote
    {
        public int Id { get; set; }
        public int UserId { get; set; }  // 這個筆記屬於哪個 User

        public AppUser User { get; set; }  // User 的導覽屬性

        public int EssentialOilId { get; set; }  // 這個筆記對應哪個 Essential Oil

        public EssentialOil EssentialOil { get; set; }  // Essential Oil 的導覽屬性

        public string Note { get; set; }  // 使用者的個人筆記內容
    }
}