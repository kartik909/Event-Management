using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventMngt.Models
{
    public class EventUser
    {
        [Key]
        public int EventUserId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual Events Events { get; set; }
        public virtual Users Users { get; set; }
    }
}