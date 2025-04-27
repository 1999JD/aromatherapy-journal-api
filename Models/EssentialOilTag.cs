using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("EssentialOilTag")]
    public class EssentialOilTag
    {
        public int EssentialOilId { get; set; }
        public EssentialOil EssentialOil { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}