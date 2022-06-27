using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Product1.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Product1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController1
        public async Task<IActionResult> Index()
        {


            List<Category> reservationList = new List<Category>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44390/api/Categories"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Category>>(apiResponse);
                }
            }

            return View(reservationList);
        }

        // GET: CategoryController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            Category cate = new Category();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44390/api/Categories", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cate = JsonConvert.DeserializeObject<Category>(apiResponse);
                    return RedirectToAction("Index");

                }
            }
            return View(cate);
        }




        // GET: CategoryController1/Edit/5


        public async Task<IActionResult> Edit(int ID)
        {
            Category cate = new Category();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44390/api/Categories/" + ID))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cate = JsonConvert.DeserializeObject<Category>(apiResponse);
                }
            }
            return View(cate);
        }


        // POST: CategoryController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category cate)
        {
            Category _cate = new Category();
            using (var httpClient = new HttpClient())
            {
                //var content = new MultipartFormDataContent();
                //content.Add(new StringContent(cate.Id.ToString()), "Id");
                //content.Add(new StringContent(cate.Name), "Name");
                //content.Add(new StringContent(cate.Summary), "Summary");

                StringContent content = new StringContent(JsonConvert.SerializeObject(cate), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:44390/api/Categories/" + cate.ID, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    _cate = JsonConvert.DeserializeObject<Category>(apiResponse);
                    return RedirectToAction("Index");
                }
            }
            return View(_cate);
        }
        // GET: CategoryController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteCate(int ID)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44390/api/Categories/" + ID))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}

