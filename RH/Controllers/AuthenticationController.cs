using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RH.Context;
using RH.DTOs;
using RH.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly RhContext _rhContext;
        private readonly ITokenService _tokenService;

        public AuthenticationController(RhContext rhContext, ITokenService tokenService)
        {
            _rhContext = rhContext;
            _tokenService = tokenService;
        }

        // POST api/<AuthenticationController>
        [HttpPost]
        public async Task<ActionResult<dynamic>> AuthenticationAsync([FromBody] EmployeeDTO dto)
        {
            var employee = await _rhContext.Employees.Include(x => x.Permission)
                .FirstOrDefaultAsync(x => x.Email == dto.Email && x.Password == dto.Password);
            if (employee is null)
            {
                return BadRequest(new { Message = "Employee not found." });
            }

            var token = _tokenService.GenerateToken(employee);

            return Ok(token);



        }




    }
}
