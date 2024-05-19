using HotelProject.BusinessLayer.Abstruct;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServicesController : ControllerBase
	{
		private readonly IServiceService _servicesService;

		public ServicesController(IServiceService servicesService)
		{
			_servicesService = servicesService;
		}

		[HttpGet]
		public IActionResult ServicesList()
		{
			var values = _servicesService.TGetList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult AddServices(Service Services)
		{
			_servicesService.TInsert(Services);
			return Ok();
		}


		[HttpDelete("{id}")]
		public IActionResult DeleteService(int id)
		{
			var values = _servicesService.TGetByID(id);
			_servicesService.TDelete(values);
			return Ok();
		}


		[HttpPut]
		public IActionResult UpdateServices(Service services)
		{
			_servicesService.TUpdate(services);
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult GetServices(int id)
		{
			var values = _servicesService.TGetByID(id);
			return Ok(values);
		}
	}
}
