using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("UserEssentailOil")]
    public class UserEssentailOil
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int EssentialId { get; set; }
        public EssentialOil EssentialOil { get; set; }
    }
}