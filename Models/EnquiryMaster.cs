using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lost_And_Found.Models
{
    [Table("EnquiryMaster")]
    public class EnquiryMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnqId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(15)]
        public string MobileNo { get; set; }

        [StringLength(300)]
        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime EnquiryDate { get; set; }
    }
}
