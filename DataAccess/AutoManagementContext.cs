using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AutoManagementContext : IAutoManagementContext
    {
        private AutoManagement context = new AutoManagement();
        public EntityDefination GetEntityDefination(string entity)
        {
            return (from en in context.EntityDefinations
                    where en.Entity == entity
                    select new EntityDefination { Entity = en.Entity, Entity_XML = en.Entity_XML }).FirstOrDefault();
        }
        public Dictionary<Guid?,string> GetEntityListFromEntityDefination(string entity)
        {
            return (from end in context.EntityDefinations
                    join en in context.Entities on end.Id equals en.EntityDefinationId
                    select new 
                    {
                        ControlId = en.ControlId,
                        ObjectId = en.ObjectId,
                        Value = en.Value
                    }).ToDictionary(x=>x.ControlId,x=>x.Value);
                   
        }

    }
}
