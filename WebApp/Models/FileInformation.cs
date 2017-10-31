using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class FileInformation
    {
        public string Id { get; set; }
        public string Parent { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string LastModified { get; set; }
        public string[] Children { get; set; }
        public string Status { get; set; }
        public String User { get; set; }
        public String Owner { get; set; }
    }
}