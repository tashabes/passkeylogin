using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using PasskeyLoginPOC.API.Data;
using PasskeyLoginPOC.API.Models.User;
using PasskeyLoginPOC.API.Static;

namespace PasskeyLoginPOC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly PassKeyUsersDbContext _context;
        private readonly IMapper mapper;
        private readonly ILogger<UsersController> logger;

        public UsersController(PassKeyUsersDbContext context, IMapper mapper, ILogger<UsersController> logger)
        {
            _context = context;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadOnlyDto>>> GetUsers()
        {
      
            try
            {
                var user = await _context.Users.ToListAsync();
                var userDto = mapper.Map<IEnumerable<UserReadOnlyDto>>(user);
                return Ok(userDto);
            }
        catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetUsers)}");
                return StatusCode(500, Messages.Error500Message);
            }

        }

        // GET: api/Users/5
        [HttpGet("{machineName}")]
        public async Task<ActionResult<UserReadOnlyDto>> GetUser(string machineName)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.MachineName == machineName);

                if (user == null)
                {
                    return NotFound();
                }

                var userDto = mapper.Map<UserReadOnlyDto>(user);
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetUsers)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                logger.LogWarning($"Update ID invalid in {nameof(PutUser)} - ID: {id}.");
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCreateDto>> PostUser(UserCreateDto userDto)
        {
            try
            {
                var user = mapper.Map<User>(userDto);
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUser), new { machineName = user.MachineName }, user);
            }
            catch (Exception ex)
            {
                return Problem("Error creating user.", null, 500, ex.Message);
            }
        }


        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {

                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    logger.LogWarning($"{nameof(User)} record not found in {nameof(DeleteUser)} - ID: {id}");
                    return NotFound();
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return NoContent();
            } catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing Delete in {nameof(DeleteUser)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        private async Task <bool> UserExists(int id)
        {
            return await _context.Users.AnyAsync(e => e.Id == id);
        }
    }
}
