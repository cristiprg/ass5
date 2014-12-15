using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using PackageWebServer;
using WebClient.PackageStatusWS;
using package = WebClient.PackageWS.package;
using PackageWebService = WebClient.PackageWS.PackageWebService;

namespace WebClient.Controllers
{
    public class PackageController : Controller
    {
        private readonly PackageWebService _packageWebServer = new PackageWebService();
        private readonly PackageStatusWebService _packageStatusWebStatusWebService = new PackageStatusWebService();
        //
        // GET: /Package/

        public ActionResult Index()
        {
            package[] packages = _packageWebServer.getAllPackages();
            if (packages.Length == 0)
            {
                return View();
            }
            else
            {
                return View(packages);
            }
        }

        //
        // GET: /Package/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Package/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Package/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var p = new package {user_id = Convert.ToInt32(Request.Form["user_id"]), content = Request.Form["content"]};

            try
            {
                _packageWebServer.addPackage(p);
                return RedirectToAction("Index");
            }
            catch (SoapException exception)
            {
                Debug.WriteLine(exception.Message);
                return View();
            }
        }

        //
        // GET: /Package/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Package/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Package/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Package/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Register(string user_id, string package_id)
        {
            _packageWebServer.registerPackage(Convert.ToInt32(user_id), Convert.ToInt32(package_id));
            return RedirectToAction("Index");
        }

        public ActionResult UpdateStatus(int package_id)
        {
            _packageStatusWebStatusWebService.UpdatePackageStatus(package_id);
            return RedirectToAction("Index");
        }
    }
}
