using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace schoolsSystems.Models.DropMenu
{
    public class FormDropMenu
    {
        public int FormId { get; set; }
        public IEnumerable<Form> forms { get; set; }
    }
}