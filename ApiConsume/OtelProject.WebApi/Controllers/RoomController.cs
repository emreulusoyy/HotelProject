using HotelProject.BusinessLayer.Abstruct;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OtelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public RoomController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddRoom(Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var values = _staffService.TGetByID(id);
            _staffService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRoom(Staff staff) 
        {

            _staffService.TUpdate(staff);
            return Ok();
        }
        [HttpGet("{id})")]
        public IActionResult GetRoom(int id)
        {
            var values = _staffService.TGetByID(id);
            return Ok(values);
        }

    }
}
