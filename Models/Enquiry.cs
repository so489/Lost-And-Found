using System;
using System.ComponentModel.DataAnnotations;

namespace Lost_And_Found.Models
{
    public class Enquiry
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime Date { get; set; }
    }
}
