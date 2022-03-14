using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealOrdering.Server.Services;
using MealOrdering.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            return new ServiceResponse<List<UserDTO>>()
            {
                Value = await _userService.GetUsers()
            };
        }

    }
}