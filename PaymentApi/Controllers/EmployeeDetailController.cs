using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentApi.Models;

namespace PaymentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailController : ControllerBase
    {
        private readonly PaymentApiContext _context;

        public EmployeeDetailController(PaymentApiContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> GetEmployeeDetails()
        {
            if (_context.EmployeeDetails == null)
            {
                return NotFound();
            }
            return await _context.EmployeeDetails.ToListAsync();
        }

        // GET: api/EmployeeDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetail>> GetEmployeeDetail(int id)
        {
            if (_context.EmployeeDetails == null)
            {
                return NotFound();
            }
            var employeeDetail = await _context.EmployeeDetails.FindAsync(id);

            if (employeeDetail == null)
            {
                return NotFound();
            }

            return employeeDetail;
        }

        // PUT: api/EmployeeDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> PutEmployeeDetail(int id, EmployeeDetail employeeDetail)
        {
            if (id != employeeDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return await _context.EmployeeDetails.ToListAsync();
        }

        // POST: api/EmployeeDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> PostEmployeeDetail(EmployeeDetail employeeDetail)
        {
            if (_context.EmployeeDetails == null)
            {
                return Problem("Entity set 'PaymentApiContext.EmployeeDetails'  is null.");
            }
            _context.EmployeeDetails.Add(employeeDetail);
            await _context.SaveChangesAsync();

            return await _context.EmployeeDetails.ToListAsync();
        }

        // DELETE: api/EmployeeDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> DeleteEmployeeDetail(int id)
        {
            if (_context.EmployeeDetails == null)
            {
                return NotFound();
            }
            var employeeDetail = await _context.EmployeeDetails.FindAsync(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            _context.EmployeeDetails.Remove(employeeDetail);
            await _context.SaveChangesAsync();

            return await _context.EmployeeDetails.ToListAsync();
        }

        private bool EmployeeDetailExists(int id)
        {
            return (_context.EmployeeDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
