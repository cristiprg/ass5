using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace PackageWebServer
{
    /// <summary>
    /// Summary description for PackageWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PackageWebService : System.Web.Services.WebService
    {
        private readonly packagetrackingEntities db = new packagetrackingEntities();

        [WebMethod]
        public void addPackage(package p)
        {
            db.packages.Add(p);
            if (db.SaveChanges() != 1)
            {
                throw new SoapException();
            }
        }

        [WebMethod]
        public List<package> getAllPackages()
        {
            return db.packages.ToList();
        }
    }
}
