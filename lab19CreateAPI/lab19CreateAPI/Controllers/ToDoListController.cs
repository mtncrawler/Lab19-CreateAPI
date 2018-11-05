using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab19CreateAPI.Models;

namespace lab19CreateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly ToDoContext _context;

        public ToDoListController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/ToDoList
        [HttpGet]
        public async Task<List<ToDoList>> GetLists()
        {
            return await _context.Lists.ToListAsync();
        }

        // GET: api/ToDoList/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDoList = await _context.Lists.FindAsync(id);

            if (toDoList == null)
            {
                return NotFound();
            }

            return Ok(toDoList);
        }

        // PUT: api/ToDoList/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoList([FromRoute] int id, [FromBody] ToDoList toDoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDoList.ID)
            {
                return BadRequest();
            }

            _context.Entry(toDoList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoListExists(id))
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

        // POST: api/ToDoList
        [HttpPost]
        public async Task<IActionResult> PostToDoList([FromBody] ToDoList toDoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lists.Add(toDoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoList", new { id = toDoList.ID }, toDoList);
        }

        // DELETE: api/ToDoList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDoList = await _context.Lists.FindAsync(id);
            if (toDoList == null)
            {
                return NotFound();
            }

            _context.Lists.Remove(toDoList);
            await _context.SaveChangesAsync();

            return Ok(toDoList);
        }

        private bool ToDoListExists(int id)
        {
            return _context.Lists.Any(e => e.ID == id);
        }
    }
}