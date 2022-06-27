using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using ServerAPI2Cline.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServerAPI2Cline.Controllers
{
    public class UserController : Controller
    {
        private string URL = "http://locahost:44328/";
        public IActionResult register()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        public IActionResult doRegister()
        {
            return View();
        }
        public IActionResult doLogin()
        {
            return View();
        }
        public async Task<IActionResult> doRegister(
            [Bind("UserName,Password,CfPassword")] User u1)
        {
            if (!u1.Password.Equals(u1.CfPassword))
            {

            }
            using (var httpClient = new HttpClient())
            {
                User u = new User();
                u.UserName = u1.UserName;
                u.Password = u1.Password;
                StringContent content = new StringContent(
                    JsonConvert.SerializeObject(u),
                    Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(URL + "api/Members/register", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //User u2 = JsonConvert.DeserializeObject<User>(apiResponse);
                }
            }
            return RedirectToAction("/user/login");
        }

        public async Task<IActionResult> doLogin([Bind("UserName,Password")] User u1,
            HttpContext context)
        {
            using (var httpClient = new HttpClient())
            {
                User u = new User();
                u.UserName = u1.UserName;
                u.Password = u1.Password;
                StringContent content = new StringContent(
                    JsonConvert.SerializeObject(u),
                    Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(URL + "/api/Members/authentication", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var session = context.Session;
                    session.SetString("TOKEN", apiResponse);
                }
            }
            return RedirectToAction("/index");
        }
    }
}
