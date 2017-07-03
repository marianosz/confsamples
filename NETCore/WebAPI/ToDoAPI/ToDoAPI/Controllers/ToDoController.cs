using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Model;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            _context = context;

            if (_context.ToDoItems.Count() == 0)
            {
                _context.ToDoItems.Add(new ToDoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.ToDoItems.ToListAsync());
        }
        
        [HttpGet("{id}", Name = "GetToDo")]
        public async Task<IActionResult> GetById(long id)
        {
            var item = await _context.ToDoItems.FirstOrDefaultAsync(t => t.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ToDoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync();

            return Created(Url.Action("GetById", new { id = item.Id }), item);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]ToDoItem todo)
        {
            if (todo == null || todo.Id != id)
            {
                return BadRequest();
            }

            if (!_context.ToDoItems.Any(t => t.Id == id))
            {
                return NotFound();
            }

            _context.ToDoItems.Update(todo);

            await _context.SaveChangesAsync();

            return NoContent();
        }   

        
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var todo = await _context.ToDoItems.FirstOrDefaultAsync(t => t.Id == id);

            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = true;

            _context.ToDoItems.Update(todo);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _context.ToDoItems.FirstOrDefaultAsync(t => t.Id == id);

            if (todo == null)
            {
                return NotFound();
            }

            _context.ToDoItems.Remove(todo);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
