using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebServer.Models
{
    public class FileInfo
    {
        public string Id { get; set; }
        public string Parent { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string LastModified { get; set; }
        public string[] Children { get; set; }
        public string Status { get; set; }
        public string User { get; set; }
        public string Owner { get; set; }

        public static FileInfo Parse(Microsoft.Extensions.FileProviders.IFileInfo info, string fileId, string parentId, string status = "closed", string user = null, string owner = null)
        {
            string type = info.IsDirectory ? "folder" : "file";
            string name = info.Name;
            string lastModified = info.LastModified.ToString();

            FileInfo f = new FileInfo
            {
                Id = fileId,
                Parent = parentId,
                Type = type,
                Name = name,
                LastModified = lastModified,
                Status = status,
                User = user,
                Owner = owner
            };

            return f;
        }

    }  
}
