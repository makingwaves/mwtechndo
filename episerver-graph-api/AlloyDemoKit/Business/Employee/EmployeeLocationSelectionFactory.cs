using System.Collections.Generic;
using EpiServer.AlloyDemo.GraphAPI.Models.Pages;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.Shell.ObjectEditing;

namespace EpiServer.AlloyDemo.GraphAPI.Business.Employee
{
    public class EmployeeLocationSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var results = SearchClient.Instance.Search<EmployeeLocationPage>()
                .OrderBy(x => x.Name)
                .Take(1000)
                .GetContentResult();

            List<SelectItem> items = new List<SelectItem>();
            foreach(var result in results)
            {
                items.Add(new SelectItem() { Text = result.Name, Value = result.Name });
            }

            return items;
        }
    }
}