using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("EssentialOilPersonalTag")]
    public class EssentialOilPersonalTag
    {
        public int PersonalTagId { get; set; }
        public PersonalTag PersonalTag { get; set; }
        public int EssentialOilId { get; set; }
        public EssentialOil EssentialOil { get; set; }

    }
}