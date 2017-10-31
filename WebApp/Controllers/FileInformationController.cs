using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using WebApp.Models;


namespace WebApp.Controllers
{
    public class FileInformationController : ApiController
    {

        FileInformation[] fileinfo = new FileInformation[]
        {
            new FileInformation {Id="a", Name="Folder-A" },
            new FileInformation {Id="b", Name="Folder-B" },
            new FileInformation {Id="c", Name="Folder-C" },
            new FileInformation {Id="d", Name="Folder-D" },
            new FileInformation {Id="e", Name="Folder-E" }
        };

        public IEnumerable<FileInformation> GetAllFileInformation()
        {
            return fileinfo;
        }

        public IHttpActionResult GetFileInformation(string id)
        {      
            var file = fileinfo.FirstOrDefault((f) => f.Id.Equals(id));
            if (file == null)
            {
                return NotFound();
            }
            return Ok(file);
        }
    }
}
