using System.Linq;
using System.Web.Mvc;
using Lost_And_Found.Models;

namespace Lost_And_Found.Controllers
{
    public class AdminController : Controller
    {
        private const string ADMIN_USER = "admin";
        private const string ADMIN_PASS = "123";

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (username == ADMIN_USER && password == ADMIN_PASS)
            {
                Session["IsAdmin"] = true;
                return RedirectToAction("Manage");
            }

            ModelState.AddModelError("", "Invalid credentials");
            return View();
        }

        private bool IsAdmin => Session["IsAdmin"] != null && (bool)Session["IsAdmin"];

        public ActionResult Manage()
        {
            if (!IsAdmin)
                return RedirectToAction("Login");

            var items = DataStore.Items.OrderByDescending(i => i.DateReported).ToList();
            return View(items);
        }

        public ActionResult Dashboard()
        {
            if (!IsAdmin)
                return RedirectToAction("Login");

            ViewBag.TotalItems = DataStore.Items.Count;
            ViewBag.PendingItems = DataStore.Items.Count(i => i.Status != LostStatus.Found);
            ViewBag.TotalEnquiries = DataStore.Enquiries.Count;
            ViewBag.TotalNotifications = DataStore.Notifications.Count;
            return View();
        }

        public ActionResult Enquiries()
        {
            if (!IsAdmin)
                return RedirectToAction("Login");

            var enquiries = DataStore.Enquiries.OrderByDescending(e => e.Date).ToList();
            return View(enquiries);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEnquiry(int id)
        {
            if (!IsAdmin)
                return RedirectToAction("Login");

            DataStore.RemoveEnquiry(id);
            return RedirectToAction("Enquiries");
        }

        public ActionResult Notifications()
        {
            if (!IsAdmin)
                return RedirectToAction("Login");

            var notes = DataStore.Notifications.OrderByDescending(n => n.Date).ToList();
            return View(notes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNotification(Notification note)
        {
            if (!IsAdmin)
                return RedirectToAction("Login");

            if (string.IsNullOrWhiteSpace(note.Message))
            {
                TempData["Error"] = "Notification message cannot be empty.";
                return RedirectToAction("Notifications");
            }

            DataStore.AddNotification(note);
            return RedirectToAction("Notifications");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteNotification(int id)
        {
            if (!IsAdmin)
                return RedirectToAction("Login");

            DataStore.RemoveNotification(id);
            return RedirectToAction("Notifications");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MarkFound(int id)
        {
            if (!IsAdmin)
                return RedirectToAction("Login");

            DataStore.MarkFound(id);
            return RedirectToAction("Manage");
        }

        public ActionResult Logout()
        {
            Session["IsAdmin"] = null;
            return RedirectToAction("Login");
        }
    }
}
