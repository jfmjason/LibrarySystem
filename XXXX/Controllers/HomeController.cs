
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using AspNetCore.Reporting;
using LS.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using XXXX.Models;

namespace XXXX.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index() {




            return View();
        }

        public IActionResult GetPdf()
        {
            var data = new List<User>();

            for (var i = 0; i < 1000; i++) {

                data.Add(
                    new User() {
                        Id = Guid.NewGuid(),
                        UserName = "User" + i.ToString(),
                        Password = "Pass" + i.ToString(),
                        Salt = "Salt" + i.ToString(),
                    });

            }

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var param = new Dictionary<string, string>(){
                { "key1", "value1" },
                { "key2", "value2" }
            };

            var x = new int[] { 2, 2 };

            var localrep = new LocalReport(@"C:\Users\Jason\Source\Repos\LibrarySystem\XXXX\ReportFiles\test.rdl");
            localrep.AddDataSource("Dataset1", data);
          
            var res = localrep.Execute(RenderType.Pdf, 1, param, null);

            return new FileStreamResult(new MemoryStream(res.MainStream)
                , "application/pdf");
        }

        public IActionResult GetPdfFile()
        {
            var data = new List<User>();

            for (var i = 0; i < 20; i++)
            {

                data.Add(
                    new User()
                    {
                        Id = Guid.NewGuid(),
                        UserName = "User" + i.ToString(),
                        Password = "Pass" + i.ToString(),
                        Salt = "Salt" + i.ToString(),
                    });

            }

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);



            var localrep = new LocalReport(@"C:\Users\Jason\Source\Repos\LibrarySystem\XXXX\ReportFiles\test.rdl");
            localrep.AddDataSource("Dataset1", data);

            var res = localrep.Execute(RenderType.Pdf);

            return File(res.MainStream,"application/pdf" );
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
