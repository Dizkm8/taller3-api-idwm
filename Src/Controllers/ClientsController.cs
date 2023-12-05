using Backend.Src.Data;
using Backend.Src.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly DataContext _context;
        public ClientsController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<List<Client>>> AllUsers()
        {
            var clients = await _context.Clients.ToListAsync();
            return clients;
        }
    }



}