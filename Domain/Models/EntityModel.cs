using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class EntityModel
    {
        public int Id { get; set; }
        public int EntityDefinationId{get;set;}
        public Guid ObjectId { get; set; }
        public Guid FormId { get; set; }
        public Guid ControlId { get; set; }
        public string Value { get; set; }

        public Dictionary<Guid, string> KeyValue { get; set; }
    }
}
