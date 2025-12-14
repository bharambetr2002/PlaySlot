using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Threading.Tasks;
using api.Models.DTOs.User;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers

{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync(CreateUserDTO dto)
        {
            await _service.AddUserAsync(dto);
            return Ok();
        }
    }
}