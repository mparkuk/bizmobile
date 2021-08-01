using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verastar.Models
{
    public class MobilePhone
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }
        public string ImagePath { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
