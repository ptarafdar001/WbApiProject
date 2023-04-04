using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nagarro.ReimbursementPortal.webAPI.DTOs;
using Nagarro.ReimbursementPortal.webAPI.Interfaces.IUow;
using Nagarro.ReimbursementPortal.webAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET "api/user"
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            //throw new UnauthorizedAccessException();

            var users = await unitOfWork.UserRepository.GetUsersAsync();

            var usersDto = mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            //throw new UnauthorizedAccessException();

            var user = await unitOfWork.UserRepository.GetRecordbyid(id);

            var usersDto = mapper.Map<IEnumerable<UserDto>>(user);

            return Ok(usersDto);
        }

        [HttpPost("post")]
        public async Task<IActionResult> AddUsers(UserDto userDto)
        {
            var type = mapper.Map<User>(userDto);

            unitOfWork.UserRepository.AddUser(type);
            await unitOfWork.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDto userDto)
        {
            if (id != userDto.Id)
                return BadRequest("Update not allowed");

            var userFromDb = await unitOfWork.UserRepository.FindUser(id);

            if (userFromDb == null)
                return BadRequest("Update not allowed");

            mapper.Map(userDto, userFromDb);

            //throw new Exception("Some Unknown Exception Occured");

            await unitOfWork.SaveAsync();
            return StatusCode(200);
        }

        
        //[HttpPut("update/{id}")]
        //public async Task<IActionResult> FindUser(int id, UserDto userDto)
        //{
        //    if (id != userDto.Id)
        //        return BadRequest("Update not allowed");

        //    var userFromDb = await Uow.UserRepository.FindUser(id);

        //    if (userFromDb == null)
        //        return BadRequest("Update not allowed");

        //    mapper.Map(userDto, userFromDb);

        //    //throw new Exception("Some Unknown Exception Occured");

        //    await Uow.SaveAsync();
        //    return StatusCode(200);
        //}


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            unitOfWork.UserRepository.DeleteUser(id);
            await unitOfWork.SaveAsync();
            return Ok(id);
        }
    }
}
