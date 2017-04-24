using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace schoolsSystems.Models.DropMenu
{
    public class DropMenu<T>
    {
        public int Id { get; set; }
        public IEnumerable<T> list { get; set; }
    }
}