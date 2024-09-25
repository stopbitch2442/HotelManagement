﻿using Microsoft.AspNetCore.Mvc;
using HotelManagement.Domain; // Убедитесь, что Employee определён в этом пространстве имен
using HotelManagement.Persistence; 
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
         private readonly HotelManagementDbContext _context;

         public EmployeeController(HotelManagementDbContext context)
         {
             _context = context;
         }

         // GET: api/employee
         [HttpGet]
         public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
         {
             return await _context.Employees.ToListAsync();
         }

         // GET: api/employee/{id}
         [HttpGet("{id}")]
         public async Task<ActionResult<Employee>> GetEmployee(int id)
         {
             var employee = await _context.Employees.FindAsync(id);

             if (employee == null)
             {
                 return NotFound();
             }

             return employee;
         }

         // POST: api/employee
         [HttpPost]
         public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
         {
             _context.Employees.Add(employee);
             await _context.SaveChangesAsync();

             return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
         }

         // PUT: api/employee/{id}
         [HttpPut("{id}")]
         public async Task<IActionResult> PutEmployee(int id, Employee employee)
         {
             if (id != employee.Id)
             {
                 return BadRequest();
             }

             _context.Entry(employee).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!EmployeeExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();
         }

         // DELETE: api/employee/{id}
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteEmployee(int id)
         {
             var employee = await _context.Employees.FindAsync(id);
             if (employee == null)
             {
                 return NotFound();
             }

             _context.Employees.Remove(employee);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         private bool EmployeeExists(int id)
         {
             return _context.Employees.Any(e => e.Id == id);
         }
     }
}