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
        public async Task<ActionResult<List<UsuarioModel>>> Get(string nome, boolen ativo)
        {
            string query = "SELECT  nome, idade, email, sexo, ativo"
                                + "FROM usuarios"
                                + "WHERE ativo = {1} "
                                + "AND nome LIKE '%{0}%' " 
            return await _context.Usuarios
            .FromSql(query)
            .ToListAsync();
        }

        // GET: api/usuario/5
        [HttpGet()]
        [Route("{id}")]
        public async Task<ActionResult<UsuarioModel>> Get(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
 
            if (usuario == null)
            {
                return NotFound();
            }
 
            return usuario;
        }

        // POST: api/usuario
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> PostUsuario(UsuarioModel usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = usuario.Id }, usuario);
        }


    }
}