using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;

namespace auto_management.Controllers
{
    public class ResourceController : ApiController
    {
        // GET api/resource
        public IHttpActionResult Get()
        {
            
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Web.Hosting.HostingEnvironment.MapPath("~/Resources/Controls.xml"));

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/controls/input");

            List<ControlsModel> controls = new List<ControlsModel>();

            foreach (XmlNode node in nodes)
            {
                ControlsModel control = new ControlsModel();

                control.Label = node.SelectSingleNode("label").InnerText;
                control.Type = node.SelectSingleNode("type").InnerText;
                control.Name = node.SelectSingleNode("name").InnerText;
                control.Values = node.SelectSingleNode("values").InnerText.Split(',');
                controls.Add(control);
            }
            return this.Ok(controls);
            
        }

        // GET api/resource/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/resource
        public void Post([FromBody]string value)
        {
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

    public class ControlsModel
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string[] Values { get; set; }

    }


}
