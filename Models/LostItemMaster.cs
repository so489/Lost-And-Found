using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lost_And_Found.Models
{
    [Table("LostItemMaster")]
    public class LostItemMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [StringLength(100)]
        public string ItemName { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(15)]
        public string MobileNo { get; set; }

        public bool IsFound { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime ReportDate { get; set; }
    }
}
