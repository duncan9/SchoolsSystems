using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace schoolsSystems.Models
{
    public class CityDropMenu
    {
        public int CityId { get; set; }
        public IEnumerable<City> cities { get; set; }
    }
}