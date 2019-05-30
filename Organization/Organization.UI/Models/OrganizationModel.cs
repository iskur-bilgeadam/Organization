using Organization.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Organization.UI.Models
{
    public class OrganizationModel
    {
        public Organizations Organizations { get; set; }
        public int NumberofUsers { get; set; }
        public Messages Message { get; set; }
        public List<Messages> Messages { get; set; }
    }
}