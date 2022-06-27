using ClientAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientAPI.Controllers
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

        public async Task<IActionResult> Register([Bind("Username,Password,cf_password")] User user)
        {
            if (user.Password.Equals(user.cf_password))
            {

            }
                using (var httpClient = new HttpClient())
                {
                    User u = new User();
                    u.Username = user.Username;
                    u.Password = user.Password;
                    StringContent content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                    using (var reponse = await httpClient.PostAsync("https://localhost:44336/api/Authen/register", content))
                    {
                        string apiResponse = await reponse.Content.ReadAsStringAsync();
                    }
                }

            return View("index");
        }
        public async Task<IActionResult> Login([Bind("Username,Password")] User user)
        {
            using (var httpClient = new HttpClient())
            {
                User u = new User();
                u.Username = user.Username;
                u.Password = user.Password;
                StringContent content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                using (var reponse = await httpClient.PostAsync("https://localhost:44336/api/Authen/authentication", content))
                {
                    string apiResponse = await reponse.Content.ReadAsStringAsync();
                    HttpContext.Session.SetString("TOKEN", apiResponse);
                }
            }

            return Redirect("/Categories");
        }
    }
}
