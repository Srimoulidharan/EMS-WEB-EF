using ems_web.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Ems
{
    [ApiController]
    [Route("api/[controller]")]
    public class EMSController : ControllerBase
    {
        StudentDBContext _context;

        public EMSController(StudentDBContext context)
        {
            _context = context;
        }
        [HttpPost("add")]
        public ActionResult AddEmployee(EMS emp)
        {
            if (emp != null)
            {
                _context.Add(emp);
                _context.SaveChanges();
                return Ok("Employee Added");
            }
            else
            {
                return BadRequest("Employee not added");
            }
        }

        [HttpGet("{id}")]
        public ActionResult getaEmployee(int id) {
            var emp = _context.Employee.Find(id);
            if (emp != null)
            {

                return Ok(emp);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet()]
        public ActionResult<List<EMS>> getEmployee()
        {
            return Ok(_context.Employee.ToList());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int  id)
        {
            var employee =await  _context.Employee.FindAsync(id);
            if (employee != null)
            {
                _context.Remove(employee);
                _context.SaveChanges();
                return Ok("Employee Deleted");
            }
            else
            {
                return BadRequest("Employee not Deleted");
            }
        }

        [HttpPut]
        public ActionResult PutEmployee(EMS emp) {
            if (emp != null)
            {
                _context.Employee.Update(emp);
                _context.SaveChanges();
                return Ok("Employee  Updated successfully");
            }
            else
            {
                return BadRequest("Employee unable to add ");
            }
        }

    }
}
