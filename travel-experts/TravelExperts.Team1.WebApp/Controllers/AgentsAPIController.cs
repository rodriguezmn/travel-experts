using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelExperts.Team1.WebApp.Models;

namespace TravelExperts.Team1.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsAPIController : ControllerBase
    {
        private readonly TravelExpertsContext _context;

        public AgentsAPIController(TravelExpertsContext context)
        {
            _context = context;
        }

        // GET: api/AgentsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agents>>> GetAgents()
        {
            return await _context.Agents.ToListAsync();
        }

        // GET: api/AgentsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agents>> GetAgents(int id)
        {
            var agents = await _context.Agents.FindAsync(id);

            if (agents == null)
            {
                return NotFound();
            }

            return agents;
        }

        // PUT: api/AgentsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgents(int id, Agents agents)
        {
            if (id != agents.AgentId)
            {
                return BadRequest();
            }

            _context.Entry(agents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentsExists(id))
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

        // POST: api/AgentsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Agents>> PostAgents(Agents agents)
        {
            _context.Agents.Add(agents);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgents", new { id = agents.AgentId }, agents);
        }

        // DELETE: api/AgentsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Agents>> DeleteAgents(int id)
        {
            var agents = await _context.Agents.FindAsync(id);
            if (agents == null)
            {
                return NotFound();
            }

            _context.Agents.Remove(agents);
            await _context.SaveChangesAsync();

            return agents;
        }

        private bool AgentsExists(int id)
        {
            return _context.Agents.Any(e => e.AgentId == id);
        }
    }
}
