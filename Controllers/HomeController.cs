using System;
using System.Linq;
using System.Web.Mvc;
using Lost_And_Found.Models;

namespace Lost_And_Found.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var notifications = DataStore.Notifications;
            var items = DataStore.GetPublicItems();
            ViewBag.Notifications = string.Join(" --- ", notifications.Select(n => n.Message));
            return View(items);
        }
    
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Report()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Report(LostItem model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.DateReported = DateTime.Now;
            // Default status on report: Pending
            model.Status = LostStatus.Pending;
            DataStore.AddLostItem(model);
            TempData["Message"] = "Your lost item report has been submitted.";
            return RedirectToAction("Index");
        }

        public ActionResult Gallery()
        {
            var items = DataStore.GetPublicItems();
            return View(items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enquiry(Enquiry enquiry)
        {
            if (string.IsNullOrWhiteSpace(enquiry.Name) || string.IsNullOrWhiteSpace(enquiry.Message))
            {
                TempData["EnquiryError"] = "Please provide name and message.";
                return RedirectToAction("Index");
            }

            enquiry.Date = DateTime.Now;
            DataStore.AddEnquiry(enquiry);
            TempData["Message"] = "Your enquiry has been sent to Admin.";
            return RedirectToAction("Index");
        }

        public ActionResult Developer()
        {
            return View();
        }
    }
}
