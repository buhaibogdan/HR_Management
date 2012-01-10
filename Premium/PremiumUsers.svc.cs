using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Premium.Users;

namespace Premium
{
    public class PremiumUsers : IService1
    {

        public string GetReqForUserType(string userType)
        {
            UserFactory userFactory = new UserFactory();
            IUser user = userFactory.CreateInstance(userType);
            return user.GetMinPoints();
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
