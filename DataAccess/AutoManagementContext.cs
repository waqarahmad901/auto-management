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
        public Dictionary<int,string> GetEntityDefination(string entity)
        {
            return (from en in context.EntityDefinations
                    where en.Entity == entity
                    select 
                    en).ToDictionary(x=>x.Id,x=>x.Entity_XML);
        }
        public Dictionary<Guid?,string> GetEntityListFromEntityDefination(string entity,Guid objectId)
        {
            return (from end in context.EntityDefinations
                    join en in context.Entities on end.Id equals en.EntityDefinationId
                    where end.Entity == entity && en.ObjectId == objectId
                    select new 
                    {
                        ControlId = en.ControlId,
                        ObjectId = en.ObjectId,
                        Value = en.Value
                    }).ToDictionary(x=>x.ControlId,x=>x.Value);
                   
        }

        public void AddEntites(Dictionary<string, string> entites)
        {
            var formId = Guid.Parse( entites.FirstOrDefault(x => x.Key == "formId").Value);
            var objectId = Guid.Parse(entites.FirstOrDefault(x => x.Key == "objectId").Value);
            var entityId = int.Parse(entites.FirstOrDefault(x => x.Key == "entityDefinationId").Value);
            var deleteEntites = from en in context.Entities
                                where en.FormId == formId && en.ObjectId == objectId
                                select en;
            context.Entities.RemoveRange(deleteEntites);

            foreach (var item in entites.Where(x => x.Key != "formId" && x.Key != "objectId" && x.Key != "entityDefinationId"))
            {
                Entity oEntity = new Entity();
                oEntity.ObjectId = objectId;
                oEntity.ControlId = Guid.Parse(item.Key);
                oEntity.FormId = formId;
                oEntity.Value = item.Value;
                oEntity.EntityDefinationId = entityId;
                context.Entities.Add(oEntity);
            }
            context.SaveChangesAsync();
        }

    }
}
