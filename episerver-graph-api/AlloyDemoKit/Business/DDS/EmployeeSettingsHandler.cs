using System;
using System.Linq;
using EpiServer.AlloyDemo.GraphAPI.Business.Employee;
using EPiServer.Data;
using EPiServer.Data.Dynamic;

namespace EpiServer.AlloyDemo.GraphAPI.Business.DDS
{
    public class EmployeeSettingsHandler
    {
        private const string StoreName = "EmployeeSettings";
    
        public bool SaveSettings(EmployeeSettingsModel data)
        {
            DynamicDataStore store = DynamicDataStoreFactory.Instance.GetStore(StoreName);
            if (store == null)
            {
                store = DynamicDataStoreFactory.Instance.CreateStore(StoreName, typeof(EmployeeSettingsModel));
            }
            else
            {
                store.DeleteAll();
            }
            Identity id = store.Save(data);
            return (id.ExternalId != Guid.Empty);
        }

        public EmployeeSettingsModel RetrieveSettings()
        {
            return RetrieveSettings(DynamicDataStoreFactory.Instance.GetStore(StoreName));
        }

        private EmployeeSettingsModel RetrieveSettings(DynamicDataStore store)
        {
            EmployeeSettingsModel model = null;
            
            if (store != null)
            {
                model = store.LoadAll<EmployeeSettingsModel>().First();
            }

            return model;
        }
    }
}