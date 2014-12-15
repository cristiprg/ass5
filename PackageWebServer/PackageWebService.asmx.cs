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
        private readonly packagetrackingEntities    db_package = new packagetrackingEntities();
        private readonly packagetrackingEntities1   db_package_tracker = new packagetrackingEntities1();

        [WebMethod]
        public void addPackage(package p)
        {
            db_package.packages.Add(p);
            if (db_package.SaveChanges() != 1)
            {
                throw new SoapException();
            }
        }

        [WebMethod]
        public List<package> getAllPackages()
        {
            return db_package.packages.ToList();
        }

        [WebMethod]
        public void registerPackage(int user_id, int package_id)
        {
            var p = new package_tracker {user_id = user_id, package_id = package_id};
            db_package_tracker.package_tracker.Add(p);
            if (db_package_tracker.SaveChanges() != 1)
            {
                throw new SoapException();
            }
        }
    }
}
