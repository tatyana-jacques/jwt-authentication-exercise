using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RH.Context;
using RH.DTOs;
using RH.Models;

namespace RH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly RhContext _context;

        public EmployeesController(RhContext context)
        {
            _context = context;
        }


        [HttpGet("listar")]
        public async Task<ActionResult<dynamic>> GetEmployees()
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employees = await _context.Employees
                .Include(x => x.Permission)
                .ToListAsync();

            var result = User.Claims.Select(x => x.Value).FirstOrDefault(x => x.Equals("Employee"));

            if (result is not null)
            {
                var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeResponse>()
                .ForMember(dest => dest.Permission, act => act.MapFrom(act => act.Permission.Name)));
                var mapper = configuration.CreateMapper();
                var employeesDTO = mapper.Map<List<EmployeeResponse>>(employees);


                return employeesDTO;

            }

            return employees;

        }


        [HttpGet("listar {id}")]
        public async Task<ActionResult<dynamic>> GetEmployee(int id)
        {
            try
            {

                var employee = await _context.Employees
                    .Include(x => x.Permission)
                    .Where(y => y.Id == id).FirstOrDefaultAsync();

                var result = User.Claims.Select(x => x.Value).FirstOrDefault(x => x.Equals("Employee"));

                if (result is not null)
                {
                    var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeResponse>()
                    .ForMember(dest => dest.Permission, act => act.MapFrom(act => act.Permission.Name)));
                    var mapper = configuration.CreateMapper();
                    var employeeDTO = mapper.Map<EmployeeResponse>(employee);

                    return employeeDTO;

                }

                return employee;
            }
            catch
            {
                return NotFound();
            }

        }


        [HttpPut("alterar-salario {id}")]
        [Authorize(Roles = ("Manager"))]
        public async Task<IActionResult> PutEmployee(int id, DTOPut change)
        {

            try
            {
                var employee = await _context.Employees
                    .Include(x => x.Permission)
                    .Where(y => y.Id == id).FirstOrDefaultAsync();

                employee.Salary = change.Salary;
                _context.Entry(employee).State = EntityState.Modified;
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

                return Ok(employee);
            }
            catch 
            {
                return NotFound();
            }          
                
           
        }

        [HttpPost("cadastrar-novo-funcionario")]
        [Authorize(Roles =("Administrator"))]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeRequest request)
        {
            try
            {
                var configuration =
                    new MapperConfiguration(cfg => cfg.CreateMap<EmployeeRequest, Employee>());
                var mapper = configuration.CreateMapper();
                var employee = mapper.Map<Employee>(request);
                if(employee.PermissionId== 1) { 
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
                }
                return BadRequest("Cadastro autorizado apenas para funcionários!");
            }
            catch (Exception e)
            {
                return StatusCode(500);

            }


        }

       
        [HttpDelete("excluir-funcionario {id}")]
        [Authorize (Roles = "Manager, Administrator")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null || employee.PermissionId != 1)
                {
                    return NotFound();
                }
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("excluir-gerente {id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null || employee.PermissionId != 2)
                {
                    return NotFound();
                }
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
