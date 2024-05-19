using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); //İstemci oluşurdum
            var responseMessage = await client.GetAsync("http://localhost:12032/api/Services");//Listeleme işlemini nereden alacağım
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Json formatında gelen veri
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData); //Json veriyi istenilen formata dönüştürdüm
                return View(values);
            }
            return View();
        }

        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//Normal olan veriyi Json formatına dönüştürme işlemi
            var responseMessaje = await client.PostAsync("http://localhost:12032/api/Services", stringContent);
            if (responseMessaje.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:12032/api/Services/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:12032/api/Services/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonDate = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonDate);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//Normal olan veriyi Json formatına dönüştürme işlemi
            var responseMessaje = await client.PutAsync("http://localhost:12032/api/Services", stringContent);
            if (responseMessaje.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
