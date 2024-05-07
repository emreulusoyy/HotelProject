using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public StaffController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); //İstemci oluşurdum
            var responseMessage = await client.GetAsync("http://localhost:12032/api/Staff");//Listeleme işlemini nereden alacağım
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Json formatında gelen veri
                var values = JsonConvert.DeserializeObject< List < StaffViewModel >> (jsonData); //Json veriyi istenilen formata dönüştürdüm
				return View(values);
			}
            return View();
        }

        public IActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> AddStaff(AddStaffViewModel model) 
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);  
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8,"application/json");//Normal olan veriyi Json formatına dönüştürme işlemi
            var responseMessaje = await client.PostAsync("http://localhost:12032/api/Staff", stringContent);
            if(responseMessaje.IsSuccessStatusCode) 
            { 
                return RedirectToAction("Index"); 
            }
            return View();
        }

        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:12032/api/Staff/{id}");
            if(responseMessage.IsSuccessStatusCode) {
            return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:12032/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
               var jsonDate = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonDate);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//Normal olan veriyi Json formatına dönüştürme işlemi
            var responseMessaje = await client.PutAsync("http://localhost:12032/api/Staff", stringContent);
            if (responseMessaje.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
           
        }

    }
}
