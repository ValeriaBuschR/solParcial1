using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fncPar.Models
{
    public class Random1
    {
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DateTime { get; set; }

        [Key]
        public int Random { get; set; }
    }
}
