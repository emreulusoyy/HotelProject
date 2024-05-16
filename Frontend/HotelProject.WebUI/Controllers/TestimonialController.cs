using HotelProject.WebUI.Models.Staff;
using HotelProject.WebUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public TestimonialController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            public async Task<IActionResult> Index()
            {
                var client = _httpClientFactory.CreateClient(); //İstemci oluşurdum
                var responseMessage = await client.GetAsync("http://localhost:12032/api/Testimonial");//Listeleme işlemini nereden alacağım
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Json formatında gelen veri
                    var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData); //Json veriyi istenilen formata dönüştürdüm
                    return View(values);
                }
                return View();
            }

            public IActionResult AddTestimonial()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> AddTestimonial(AddTestimonialViewModel model)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//Normal olan veriyi Json formatına dönüştürme işlemi
                var responseMessaje = await client.PostAsync("http://localhost:12032/api/Testimonial", stringContent);
                if (responseMessaje.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }

            public async Task<IActionResult> DeleteTestimonial(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync($"http://localhost:12032/api/Testimonial/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }

            [HttpGet]
            public async Task<IActionResult> UpdateTestimonial(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:12032/api/Testimonial/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonDate = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdateTestimonialViewModel>(jsonDate);
                    return View(values);
                }
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialViewModel model)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//Normal olan veriyi Json formatına dönüştürme işlemi
                var responseMessaje = await client.PutAsync("http://localhost:12032/api/Testimonial", stringContent);
                if (responseMessaje.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();

            }

        }
    }

