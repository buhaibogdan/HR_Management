using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Premium
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetReqForUserType(string userType);

        [OperationContract]
        HomeAddress GetHomeAddress(string email);

    }



    [DataContract]
    public class User { 
        [DataMember]
        public int id {get;set;}
        [DataMember]
        public string email { get; set; }
    }

    [DataContract]
    public class HomeAddress
    {
        [DataMember]
        public int PostalCode { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public int Apartment {get;set; }
    }
}
