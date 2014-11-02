using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Mvc.JQuery.Datatables;

[assembly: PreApplicationStartMethod(typeof(auto_management.RegisterDatatablesModelBinder), "Start")]

namespace auto_management {
    public static class RegisterDatatablesModelBinder {
        public static void Start() {
            if (!ModelBinders.Binders.ContainsKey(typeof(DataTablesParam)))
                ModelBinders.Binders.Add(typeof(DataTablesParam), new Mvc.JQuery.Datatables.DataTablesModelBinder());
        }
    }
}
