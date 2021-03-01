using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itbit_asp_net_core.model;
using itbit_asp_net_core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace itbit_asp_net_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public UsuarioController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/usuario
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<UsuarioModel>>> Get()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // POST: api/usuario
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<UsuarioModel>> PostUsuario(UsuarioModel usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = usuario.Id }, usuario);
        }


    }
}