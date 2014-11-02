using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IAutoManagementContext
    {
        Dictionary<int, string> GetEntityDefination(string entity);
        Dictionary<Guid?, string> GetEntityListFromEntityDefination(string entity, Guid objectId);
        void AddEntites(Dictionary<string, string> entites);
        List<EntityModel> GetEntitiesByFormId(Guid formId);



    }
}
