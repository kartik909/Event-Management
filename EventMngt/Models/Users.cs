using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventMngt.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserOrganization { get; set; }
        public string UserDesignation { get; set; }

        public ICollection<EventUser> EventUser { get; set; }


    }
}