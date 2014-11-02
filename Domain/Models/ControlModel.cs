using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ControlsModel
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string[] Values { get; set; }
        public string value { get; set; }

        public Guid Id { get; set; }
    }
}
