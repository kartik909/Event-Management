using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventMngt.Models
{
    public class Events
    {
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventLocation { get; set; }
        public string EventOrganizer { get; set; }
        public DateTime EventDate { get; set; }

        public ICollection<EventUser> EventUser { get; set; }
    }
}