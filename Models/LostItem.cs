using System;
using System.ComponentModel.DataAnnotations;

namespace Lost_And_Found.Models
{
    public enum LostStatus
    {
        Pending,
        WithAdmin,
        Found
    }

    public class LostItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string ReporterName { get; set; }

        public string Contact { get; set; }

        public DateTime DateReported { get; set; }

        public LostStatus Status { get; set; }
    }
}
