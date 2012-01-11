using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using HRManagement.Models;
using HRManagement.Salary_Restfull;
using System.Net;
using System.Xml;
using HRManagement.PremiumUsers_Soap;

namespace HRManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string pas1 = HRManagement.Models.Entities.User.Md5EncryptPassword("ceva");
            string pas2 = HRManagement.Models.Entities.User.Md5EncryptPassword("ceva");
            return View();
        }

        public ActionResult Help()
        {
            #region InvokeRest
            WebRequest request = WebRequest.Create("http://localhost:50616/RestService.svc/GetContributions");
            WebResponse response = request.GetResponse();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(response.GetResponseStream());
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList xmlList = xmlDoc.GetElementsByTagName("string");
            List<string> contributii = new List<string>();

            foreach (XmlNode xmlNode in xmlList)
            {
                contributii.Add(xmlNode.InnerText);
            }
            #endregion

            PremiumUsers_Soap.HomeAddress bla = InvokeSoap();
            string reqs = GetReqForUser("vipuser");

            ViewBag.NormalUser = "Normal User: " + GetReqForUser("normaluser");
            ViewBag.PremiumUser = "Premium User: " + GetReqForUser("premiumuser");
            ViewBag.VIPUser = "VIP User: " + GetReqForUser("vipuser");
            ViewBag.PlatinumUser = "PlatinumUser: " + GetReqForUser("platinumuser");

            return View();
        }

        public ActionResult Leave()
        {
            return View();
        }

        private PremiumUsers_Soap.HomeAddress InvokeSoap()
        {
            PremiumUsers_Soap.Service1Client client = new PremiumUsers_Soap.Service1Client();
            PremiumUsers_Soap.HomeAddress address = client.GetHomeAddress("bb@email.com");

            return address;
        }

        private string GetReqForUser(string userType)
        {
            PremiumUsers_Soap.Service1Client client = new PremiumUsers_Soap.Service1Client();
            return client.GetReqForUserType(userType);
        }
    }
}
