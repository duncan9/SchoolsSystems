using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace schoolsSystems.Models
{
    public class DayOfTimeTable
    {
        public int SchoolId { get; set; }
        public int SchoolFormId { get; set; }
        public IEnumerable<TimeTable> listOfDay { get; set; }
    }
}