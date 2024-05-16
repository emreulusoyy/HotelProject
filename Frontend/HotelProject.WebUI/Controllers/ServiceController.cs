using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
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
    }
}
