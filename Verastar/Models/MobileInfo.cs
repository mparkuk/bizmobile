using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verastar.Models
{
    public class MobileInfo
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        //public string RAM { get; set; }
        public string Colors { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
