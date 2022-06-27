using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in both code and config file together.
    public class Service2 : IService2
    {
        public void DoWork()
        {
        }
        public List<Employee> getAllEmp()
        {
            List<Employee> LsE = new List<Employee>();
            Employee e = new Employee();
            e.Id = 1;
            e.Name = "Minh Duc";
            LsE.Add(e);
            return LsE;
        }

        
    }
}
