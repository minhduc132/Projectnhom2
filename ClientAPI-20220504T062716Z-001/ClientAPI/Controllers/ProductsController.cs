using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientAPI.Data;
using ClientAPI.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace ClientAPI.Controllers
{
    public class ProductsController : Controller
    {
        List<Category> _categories = new();

        Category _category = new Category();

        List<Product> _oProducts = new();

        Product _oProduct = new Product();

        HttpClientHandler _clientHandler = new HttpClientHandler();
        [HttpGet]
        // GET: CatalogController1
        public async Task<IActionResult> Index()
        {

            _oProducts = new List<Product>();
            using (var httpClient = new HttpClient())
            {
                HttpContext.Session.TryGetValue("TOKEN", out var token);
                var token2 = Encoding.UTF8.GetString(token, 0, token.Length);
                httpClient.DefaultRequestHeaders.Authorization =
                  new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token2);

                using (var response = await httpClient.GetAsync("https://localhost:44336/api/Products"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oProducts = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }

            return View(_oProducts);
        }


        public async Task<IActionResult> GetCategory()
        {

            _categories = new List<Category>();
            using (var httpClient = new HttpClient())
            {
                HttpContext.Session.TryGetValue("TOKEN", out var token);
                var token2 = Encoding.UTF8.GetString(token, 0, token.Length);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token2);

                using (var response = await httpClient.GetAsync("https://localhost:44336/api/Categories"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _categories = JsonConvert.DeserializeObject<List<Category>>(apiResponse);
                    SelectList selectLists = new SelectList(_categories, "Id", "Name");
                    ViewData["CategoryId"] = selectLists;
                }


            }
            return null;
        }

        // GET: CatalogController1/Create
        public ViewResult Create() => View();
        // POST: CatalogController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product prod,Category cate)
        {
            _oProduct = new Product();
            _categories = new List<Category>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(prod), Encoding.UTF8, "application/json");
                HttpContext.Session.TryGetValue("TOKEN", out var token);
                var token2 = Encoding.UTF8.GetString(token, 0, token.Length);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token2);

                //using (var response = await httpClient.GetAsync("https://localhost:44336/api/Categories"))
                //{
                //    string apiResponse = await response.Content.ReadAsStringAsync();
                //    _categories = JsonConvert.DeserializeObject<List<Category>>(apiResponse);
                //    ViewData["CategoryId"] = _categories;
                    using (var response = await httpClient.PostAsync("https://localhost:44336/api/Products", content))
                    {
                        
                         string apiResponse = await response.Content.ReadAsStringAsync();
                        _oProduct = JsonConvert.DeserializeObject<Product>(apiResponse);
                        ViewData["CategoryId"] = _oProduct.GetHashCode();
                        return RedirectToAction(nameof(Index));
                    }

                return View(_oProduct);
            }

        }


        // GET: CatalogController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            Product producct = new Product();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync("https://localhost:44336/api/Products/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    producct = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return View(producct);
        }

        // POST: CatalogController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product prod)
        {
            _oProduct = new Product();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(prod), Encoding.UTF8, "application/json");
                HttpContext.Session.TryGetValue("TOKEN", out var token);
                var token2 = Encoding.UTF8.GetString(token, 0, token.Length);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token2);

                using (var response = await httpClient.PutAsync("https://localhost:44336/api/Products/" + prod.Id, content1))
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(prod.Id.ToString()), "Id");
                    content.Add(new StringContent(prod.Name), "Name");
                    content.Add(new StringContent(prod.Desc), "Desc");
                    content.Add(new StringContent(prod.Price.ToString()), "Price");
                    content.Add(new StringContent(prod.Quantity.ToString()), "Quantity");
                    content.Add(new StringContent(prod.DiscountPersen.ToString()), "DiscountPersen");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oProduct = JsonConvert.DeserializeObject<Product>(apiResponse);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(_oProduct);
        }
        // GET: CatalogController1/Delete/5
        public ActionResult Delete(int Id)
        {
            return View();
        }

        // POST: CatalogController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(int Id)
        {

            using (var httpClient = new HttpClient(_clientHandler))
            {
                HttpContext.Session.TryGetValue("TOKEN", out var token);
                var token2 = Encoding.UTF8.GetString(token, 0, token.Length);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token2);

                using (var response = await httpClient.DeleteAsync("https://localhost:44336/api/Products/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
