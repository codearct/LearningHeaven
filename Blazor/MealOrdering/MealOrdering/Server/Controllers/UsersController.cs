using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealOrdering.Server.Services;
using MealOrdering.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.ResponseModels;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("login")]
        public async Task<ServiceResponse<UserLoginResponseDTO>> Login(UserLoginRequestDTO userLoginRequest)
        {
            return new ServiceResponse<UserLoginResponseDTO>
            {
                Value = await _userService.Login(userLoginRequest.Email, userLoginRequest.Password)
            };
        }

        [HttpGet]
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            return new ServiceResponse<List<UserDTO>>()
            {
                Value = await _userService.GetUsers()
            };
        }

        [HttpPost]
        public async Task<ServiceResponse<UserDTO>> CreateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await _userService.CreateUser(User)
            };
        }

        [HttpPut]
        public async Task<ServiceResponse<UserDTO>> UpdateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await _userService.UpdateUser(User)
            };
        }

        [HttpGet("{Id}")]
        public async Task<ServiceResponse<UserDTO>> GetUserById(Guid Id)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await _userService.GetUserById(Id)
            };
        }


        [HttpDelete]
        public async Task<ServiceResponse<bool>> DeleteUser([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await _userService.DeleteUser(id)
            };
        }

    }
}