using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LFIAzureDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace LFIAzureDotNetCore.Controllers
{
    public class HomeController : Controller
    {

        private IHostingEnvironment Environment;

        public HomeController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }



        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
*/
        /*        public string Index()
                {
                    return "This is my default action...";


                }*/


        public IActionResult Index()
        {
            return View();
        
        }

/*        public IActionResult Privacy()
        {
            return View();
        }*/


        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";


        }


        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.
            // string path = Path.Combine(this.Environment.WebRootPath, "Files/") + fileName;
            string path = Path.Combine(this.Environment.WebRootPath, fileName);


            Console.WriteLine($"Trying to download file from path: {path}");

            // Check if the file exists to avoid exceptions.
            if (!System.IO.File.Exists(path))
            {
                Console.WriteLine($"File not found: {path}");
                return null; // You can return an appropriate error view or message.
            }

            //Read the File data into Byte Array.
            byte[] bytes = null;

            try
            {

                bytes = System.IO.File.ReadAllBytes(path);
            }

            catch (Exception e) {
                
                Console.WriteLine("Error occurred while downloading the file: " + ex.Message);

                Console.WriteLine(e.StackTrace);

                 return null;

            }


            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }



        /*public IActionResult Privacy()
        {
            return View();
        }

        */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
