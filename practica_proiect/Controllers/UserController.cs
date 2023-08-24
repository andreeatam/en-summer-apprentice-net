using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using practica_proiect.Models.Dto;
using practica_proiect.Models;
using practica_proiect.Repositories;

namespace practica_proiect.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            var usr = _userRepository.GetAll();

            if (usr == null)
            {
                return NotFound();
            }

            var dToUser = _mapper.Map<List<UserDto>>(usr);
            return Ok(dToUser);
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            User u = await _userRepository.GetById(id);
            var userDto = _mapper.Map<UserDto>(u);

            return Ok(userDto);
        }
    }
}
