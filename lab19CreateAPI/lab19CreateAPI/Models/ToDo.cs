using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab19CreateAPI.Models
{
    public class ToDo
    {
        public int ID { get; set; }

        public string Task { get; set; }

        public bool IsDone { get; set; }
    }
}
