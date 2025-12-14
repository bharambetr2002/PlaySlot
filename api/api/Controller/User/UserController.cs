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
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _service.DeleteUserByIdAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult> GetAllUser()
        {
            var turfs = await _service.GetAllUsersAsync();
            return Ok(turfs);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetUserByIdAsync(int id)
        {
            var temp = await _service.GetUserByIdAsync(id);
            if (temp == null) return NotFound();

            return Ok(temp);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] CreateUserDTO dto)
        {
            var updated = await _service.UpdateUserAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }
    }
}