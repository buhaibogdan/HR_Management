using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace Premium
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IRestService
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetNetIncome/{UsereEmail}")]
        int GetNetIncome(string UsereEmail);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetGrossIncome/{UsereEmail}")]
        int GetGrossIncome(string UsereEmail);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetContributions/")]
        List<string> GetContributions();
    }

    [DataContract]
    public class Salary
    { 
        [DataMember]
        public string email {get;set;} 
        [DataMember]
        public int NetIncome {get;set;}
        [DataMember]
        public int GrossIncome {get;set;}
    }
}
