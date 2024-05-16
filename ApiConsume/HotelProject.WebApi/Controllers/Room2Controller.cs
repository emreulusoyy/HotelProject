
using AutoMapper;
using HotelProject.BusinessLayer.Abstruct;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomSErvice;
        private readonly IMapper _mapper;

        public Room2Controller(IRoomService roomSErvice, IMapper mapper)
        {
            _roomSErvice = roomSErvice;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values =  _roomSErvice.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddRoom(RoomAddDto roomAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(roomAddDto);
            _roomSErvice.TInsert(values);
            return Ok("Başarıyla eklendi."); 
        }

        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var values = _mapper.Map<Room>(updateRoomDto);
            _roomSErvice.TUpdate(values);
            return Ok("Başarıyla güncellendi.");    
        }
    }
}
