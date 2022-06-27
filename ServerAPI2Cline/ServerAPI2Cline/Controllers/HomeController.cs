using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using ServerAPI2Cline.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServerAPI2Cline.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        public async Task<IActionResult> register(
         [Bind("UserName,Password,CfPassword")] User u1)
        {
            if (!u1.Password.Equals(u1.CfPassword))
            {

            }
            using (var httpClient=new HttpClient())
            {
                User u = new User();
                u.UserName = u1.UserName;
                u.Password = u1.Password;
                StringContent content = new StringContent(
                    JsonConvert.SerializeObject(u),
                    Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44328/api/Authen/register", content))
                {
                    string apiResponse =await response.Content.ReadAsStringAsync();
                }
            }
            return View("index");
        }
        //login
        public async Task<IActionResult> login([Bind("UserName,Password")] User u1)
        {
            using (var httpClient = new HttpClient())
            {
                User u = new User();
                u.UserName = u1.UserName;
                u.Password = u1.Password;
                StringContent content = new StringContent(
                    JsonConvert.SerializeObject(u),
                      Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44328/api/Authen/authentication", content))

                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    HttpContext.Session.SetString("TOKEN", apiResponse);
                   
                }
                // return View("Privacy");
                return Redirect("/Categories");
            }
         }

     }
}
