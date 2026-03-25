using System.Collections.Generic;
using System.Linq;

namespace Lost_And_Found.Models
{
    public static class DataStore
    {
        private static int _nextItemId = 1;
        private static int _nextEnquiryId = 1;
        private static int _nextNotificationId = 1;

        public static List<LostItem> Items { get; } = new List<LostItem>();
        public static List<Notification> Notifications { get; } = new List<Notification>()
        {
            new Notification{ Id = _nextNotificationId++, Message = "Welcome to Lost & Found Portal", Date = System.DateTime.Now },
        };

        public static List<Enquiry> Enquiries { get; } = new List<Enquiry>();

        public static void AddLostItem(LostItem item)
        {
            item.Id = _nextItemId++;
            Items.Add(item);
        }

        public static void AddNotification(Notification n)
        {
            n.Id = _nextNotificationId++;
            n.Date = System.DateTime.Now;
            Notifications.Add(n);
        }

        public static void RemoveNotification(int id)
        {
            Notifications.RemoveAll(x => x.Id == id);
        }

        public static IEnumerable<LostItem> GetPublicItems()
        {
            // Public gallery shows items that are not marked Found
            return Items.Where(i => i.Status != LostStatus.Found).OrderByDescending(i => i.DateReported).ToList();
        }

        public static void MarkFound(int id)
        {
            var it = Items.FirstOrDefault(i => i.Id == id);
            if (it != null)
            {
                it.Status = LostStatus.Found;
            }
        }

        public static void AddEnquiry(Enquiry e)
        {
            e.Id = _nextEnquiryId++;
            Enquiries.Add(e);
        }

        public static void RemoveEnquiry(int id)
        {
            Enquiries.RemoveAll(x => x.Id == id);
        }
    }
}
