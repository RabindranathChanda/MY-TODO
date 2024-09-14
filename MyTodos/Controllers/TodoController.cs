using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTodos.Models;

namespace MyTodos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodosDbContext _context;

        public TodoController(TodosDbContext context)
        {
            _context = context;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todos>>> GetTodo()
        {
            return await _context.Todo.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todos>> GetTodos(int id)
        {
            var todos = await _context.Todo.FindAsync(id);

            if (todos == null)
            {
                return NotFound();
            }

            return todos;
        }

        // PUT: api/Todo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodos(int id, Todos todos)
        {
            if (id != todos.TodoId)
            {
                return BadRequest();
            }

            _context.Entry(todos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.Todo.ToListAsync());
        }

        // POST: api/Todo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Todos>> PostTodos(Todos todos)
        {
            _context.Todo.Add(todos);
            await _context.SaveChangesAsync();

            return Ok(await _context.Todo.ToListAsync());
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodos(int id)
        {
            var todos = await _context.Todo.FindAsync(id);
            if (todos == null)
            {
                return NotFound();
            }

            _context.Todo.Remove(todos);
            await _context.SaveChangesAsync();

            return Ok(await _context.Todo.ToListAsync());
        }

        private bool TodosExists(int id)
        {
            return _context.Todo.Any(e => e.TodoId == id);
        }
    }
}
