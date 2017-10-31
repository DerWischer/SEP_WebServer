using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebServer.Models;
using Microsoft.Extensions.FileProviders;

namespace WebServer.Controllers
{
    [Produces("application/json")]
    [Route("api/FileInfo")]
    public class FileInfoController : Controller
    {
        private readonly IFileProvider fileProvider;

        public FileInfoController(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }

        [HttpGet] // url: api/fileinfo
        public IEnumerable<FileInfo> GetAllFiles()
        {
            return scanRecursively("Storage/", "null");
        }

        [HttpGet("{id}")] // url: api/fileinfo/{id}
        public IActionResult GetFileById(string Id)
        {
            FileInfo f = GetAllFiles().FirstOrDefault((var) => var.Id.Equals(Id));
            if (f == null)
                return NotFound();
            return Ok(f);
        }
        
        private IEnumerable<FileInfo> scanRecursively(string path, string parentId)
        {            
            List<FileInfo> files = new List<FileInfo>();

            IDirectoryContents contents = fileProvider.GetDirectoryContents(path);
            foreach (IFileInfo fi in contents)
            {                
                if (fi.Exists)
                {
                    string id = System.Guid.NewGuid().ToString();
                    FileInfo f = FileInfo.Parse(fi, id, parentId);
                    
                    if (fi.IsDirectory)
                    {
                        List<FileInfo> children = new List<FileInfo>();
                        string dirName = fi.Name;
                        children.AddRange(scanRecursively(path + dirName + "/", id)); // recursively scan children
                        f.Children = children.Where(child => child.Parent.Equals(id)).Select(child => child.Id).ToArray();
                        files.AddRange(children);
                    }
                    files.Add(f);
                }               
            }            
            return files;
        }
        

    }
}