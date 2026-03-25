using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lost_And_Found.Models
{
    [Table("NotificationMaster")]
    public class NotificationMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotiId { get; set; }

        public string Message { get; set; }

        public DateTime AddedOn { get; set; }
    }
}
