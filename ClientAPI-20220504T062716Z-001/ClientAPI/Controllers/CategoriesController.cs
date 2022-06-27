﻿using ClientAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientAPI.Controllers
{
    public class CategoriesController : Controller
    {
        List<Category> _oCategories = new();

        Category _oCategory = new Category();

        HttpClientHandler _clientHandler = new HttpClientHandler();
        [HttpGet]
        // GET: CatalogController1
        public async Task<IActionResult> Index()
        {

            _oCategories = new List<Category>();
            using (var httpClient = new HttpClient())
            {
                HttpContext.Session.TryGetValue("TOKEN", out var token);
                var token2 = Encoding.UTF8.GetString(token,0,token.Length);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token2);

                using (var response = await httpClient.GetAsync("https://localhost:44336/api/Categories"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oCategories = JsonConvert.DeserializeObject<List<Category>>(apiResponse);
                }
            }

            return View(_oCategories);
        }


        // GET: CatalogController1/Create
        public ViewResult Create() => View();
        // POST: CatalogController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category cate)
        {
            _oCategory = new Category();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                HttpContext.Session.TryGetValue("TOKEN", out var token);
                var token2 = Encoding.UTF8.GetString(token, 0, token.Length);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token2);

                StringContent content = new StringContent(JsonConvert.SerializeObject(cate), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44336/api/Categories", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oCategory = JsonConvert.DeserializeObject<Category>(apiResponse);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(_oCategory);
        }


        // GET: CatalogController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            Category category = new Category();
            using (var httpClient = new HttpClient())
            {
                HttpContext.Session.TryGetValue("TOKEN", out var token);
                var token2 = Encoding.UTF8.GetString(token, 0, token.Length);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token2);

                using (var response = await httpClient.GetAsync("https://localhost:44336/api/Categories/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<Category>(apiResponse);
                }
            }
            return View(category);
        }

        // POST: CatalogController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category cate)
        {
            _oCategory = new Category();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(cate), Encoding.UTF8, "application/json");
                HttpContext.Session.TryGetValue("TOKEN", out var token);
                var token2 = Encoding.UTF8.GetString(token, 0, token.Length);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token2);

                using (var response = await httpClient.PutAsync("https://localhost:44336/api/Categories/"+ cate.Id,content1))
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(cate.Id.ToString()), "Id");
                    content.Add(new StringContent(cate.Name), "Name");
                    content.Add(new StringContent(cate.Desc), "Desc");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oCategory = JsonConvert.DeserializeObject<Category>(apiResponse);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(_oCategory);
        }
        // GET: CatalogController1/Delete/5
        public ActionResult Delete(int Id)
        {
            return View();
        }

        // POST: CatalogController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(int Id)
        {

            using (var httpClient = new HttpClient(_clientHandler))
            {
                HttpContext.Session.TryGetValue("TOKEN", out var token);
                var token2 = Encoding.UTF8.GetString(token, 0, token.Length);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token2);

                using (var response = await httpClient.DeleteAsync("https://localhost:44336/api/Categories/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
