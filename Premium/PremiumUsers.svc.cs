using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Premium
{
    public class PremiumUsers : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
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

        
        public bool isPremiumUser(string email)
        {
            return true;
        }

        public HomeAddress GetHomeAddress(string email)
        { 
            return new HomeAddress{
                PostalCode = 66541,
                Street = "Unknown",
                Number = 13,
                City = "Cluj Napoca",
                Apartment = 13 
            };
        }

    }
}
