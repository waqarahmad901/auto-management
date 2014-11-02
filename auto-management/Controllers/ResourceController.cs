using DataAccess;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Xml;

namespace auto_management.Controllers
{
    public class ResourceController : ApiController
    {
        private IAutoManagementContext context = null;
        public ResourceController()
        {
            context = new AutoManagementContext();
        }
        public ResourceController(IAutoManagementContext cont)
        {
            this.context = cont;
        }
        // GET api/resource

        //public IHttpActionResult GetEntityDefination(string formName)
        //{



        //}


        public IHttpActionResult Get(string formName, string objectId)
        {
            Dictionary<Guid?,string> entityList = null;
            if (!string.IsNullOrEmpty(objectId) && objectId != "empty")
            {
                entityList = context.GetEntityListFromEntityDefination(formName, Guid.Parse(objectId));
            }
            var entityDefination = context.GetEntityDefination(formName);

            XmlDocument doc = new XmlDocument();
            doc.Load(System.Web.Hosting.HostingEnvironment.MapPath("~/Resources/" + entityDefination.FirstOrDefault().Value));
            EntityDefinationModel entity = new EntityDefinationModel();

            XmlNodeList controlNodes = doc.DocumentElement.SelectNodes("form/control/input");

            XmlNode entityNode = doc.DocumentElement;
            string identityValue = entityNode.SelectSingleNode("identity").InnerText;

            entity.FormId = Guid.Parse(identityValue);

            if (!string.IsNullOrEmpty(objectId) && objectId != "empty")
            {
                entity.Title = entityNode.SelectSingleNode("title/update").InnerText;
                entity.ObjectId = Guid.Parse(objectId);
            }
            else
            {
                entity.Title = entityNode.SelectSingleNode("title/add").InnerText;
                entity.ObjectId = Guid.NewGuid();
            }
            entity.EntityDefinationId = entityDefination.FirstOrDefault().Key;

            List<ControlsModel> controls = new List<ControlsModel>();

            foreach (XmlNode node in controlNodes)
            {

                ControlsModel control = new ControlsModel();
                control.Label = node.SelectSingleNode("label").InnerText;
                control.Type = node.SelectSingleNode("type").InnerText;
                control.Name = node.SelectSingleNode("name").InnerText;
                control.Values = node.SelectSingleNode("values").InnerText.Split(',');
                control.Id = Guid.Parse(node.SelectSingleNode("id").InnerText);
                if (!string.IsNullOrEmpty(objectId) && objectId != "empty")
                {
                    var entityValue = entityList.FirstOrDefault(x => x.Key == control.Id);
                    control.value = entityValue.Value;
                }
                controls.Add(control);
            }

            entity.ControlModelList = controls;

            return this.Ok(entity);
        }

        // GET api/resource/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/resource
        public IHttpActionResult Post([FromBody] dynamic value)
        {
            string response = Convert.ToString(value);
            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<Dictionary<string, string>>(response);
            context.AddEntites(dict);
            return this.Ok();

        }

        // PUT api/resource/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/resource/5
        public void Delete(int id)
        {
        }
    }

   

   

  


}
