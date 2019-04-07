using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Classes
{
    public class ServiceList
    {
        private Dictionary<string, ServiceInfo> serviceList = new Dictionary<string, ServiceInfo>();

        public void Add(string name, int firstPage, int lastPage)
        {
            if (WasServiceAdded(name)) throw new Exception();
            Create(name, firstPage, lastPage);
        }

        public void Add(List<ServiceInfo> services)
        {
            var addedCount = 0;

            services.ForEach(s =>
            {
                if (!WasServiceAdded(s.name))
                {
                    Create(s.name, s.firstPage, s.lastPage);
                    addedCount++;
                }
            });

            if (addedCount == 0)
            {
                throw new Exception();
            }
        }

        public void Generate()
        {
            var list = ServicesGenerator.Generate();
            Add(list);
        }

        public ServiceInfo? GetServiceInfo(string name)
        {
            if (serviceList.ContainsKey(name)) return serviceList[name];
            return null;
        }

        public List<string> GetStringList()
        {
            List<string> list = new List<string>();

            foreach (var keyValuePair in serviceList)
            {
                var service = keyValuePair.Value;
                var serviceStr = $"name: {service.name}, firstPage: {service.firstPage}, lastPage: {service.lastPage}";
                list.Add(serviceStr);
            }

            if (list.Count == 0)
            {
                list.Add("services was not added");
            }

            return list;
        }

        public void Remove(string name)
        {
            if (!WasServiceAdded(name)) throw new Exception();
            serviceList.Remove(name);
        }

        private void Create(string name, int firstPage, int lastPage)
        {
            ServiceInfo service = new ServiceInfo(name, firstPage, lastPage);
            serviceList[name] = service;
        }

        private bool WasServiceAdded(string name)
        {
            return serviceList.ContainsKey(name);
        }
    }
}
