using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Lab02.Controllers
{
    public class FilesController : Controller
    {
        string[] files = Directory.GetFiles(@"..\Lab02\TextFiles");
        private readonly IHostingEnvironment _hostingEnvironment;

        public FilesController(IHostingEnvironment hostingEnvironment){
            _hostingEnvironment = hostingEnvironment;
        } 
        public IActionResult Index()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            //return Content(webRootPath + "\n" + contentRootPath);

            return View(files);

            
            //return View();
        }
        public IActionResult Display(int id)
        {
            string f = files[id];
            string text = File.ReadAllLines(f);
            return Content(f);
            // string[] files = Directory.GetFiles(@"..\Lab02\TextFiles");
            // return View(files);
        }

    }
}