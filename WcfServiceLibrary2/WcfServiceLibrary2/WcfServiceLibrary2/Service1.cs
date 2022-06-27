using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public double DoiTien(double a)
        {
            return a;
        }

        public double convertCurrency(double value, string currency)
        {
            double changedValue = 0;
            switch (currency)
            {
                case "USD":
                    changedValue = value * 23260;
                    return changedValue;
                case "EUR":
                    changedValue = value * 27061;
                    return changedValue;
                case "AUD":
                    changedValue = value * 16798;
                    return changedValue;
                case "JPY":
                    changedValue = value * 20704;
                    return changedValue;
                default:
                    return changedValue;
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
