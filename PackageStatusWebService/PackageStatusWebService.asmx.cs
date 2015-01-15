using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace PackageStatusWebService
{
    /// <summary>
    /// Summary description for PackageStatusWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PackageStatusWebService : System.Web.Services.WebService
    {

        private readonly packagetrackingEntities db_package = new packagetrackingEntities();

        [WebMethod]
        public void UpdatePackageStatus(int package_id)
        {
            var p = db_package.packages.Single(j => j.id == package_id);
            ++p.status;
            if (db_package.SaveChanges() != 1)
            {
               throw new Exception("Error occured while updating package " +  package_id);
            }
        }

        [WebMethod]
        public void UpdatePackageContent(int package_id, String content)
        {
            var p = db_package.packages.Single(j => j.id == package_id);
            p.content += content + " - ";
            if (db_package.SaveChanges() != 1)
            {
                throw new Exception("Error occured while updating package " + package_id);
            }
        }
    }
}
