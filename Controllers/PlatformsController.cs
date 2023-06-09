using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOS;
using PlatformService.Models;

namespace PlatformService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {

            Console.WriteLine("--> Getting Platforms ...");

            var platformItem = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platformItem));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatformById(int id)
        {

            Console.WriteLine("--> Getting Platforms ...");

            var platformItem = _repository.GetPlatformById(id);
            if(platformItem!= null)
                return Ok(_mapper.Map<PlatformReadDTO>(platformItem));

            return NotFound();
        }
        [HttpPost]
        public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTO PlatformCreateDto){

            var platformModel = _mapper.Map<Platform>(PlatformCreateDto);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDTO>(platformModel);

            return CreatedAtRoute( nameof(GetPlatformById), new {Id = platformReadDto.Id}, platformReadDto);
            
        }
    }
}