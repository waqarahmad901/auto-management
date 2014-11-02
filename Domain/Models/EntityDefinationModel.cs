using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   public class EntityDefinationModel
   {
       public EntityDefinationModel()
        {
            ControlModelList = new List<ControlsModel>();
        }
        public int EntityDefinationId { get; set; }
        public bool isEdit { get; set; }
        public string Title { get; set; }
        public Guid FormId { get; set; }
        public Guid ObjectId { get; set; }
        public List<ControlsModel> ControlModelList { get; set; }
    }
}
