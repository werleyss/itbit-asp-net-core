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
        public async Task<ActionResult<List<UsuarioModel>>> Get(string nome, bool ativo)
        {
            
            return await _context.Usuarios.FromSqlRaw("SELECT id, nome, DataNascimento, CAST(DATEDIFF(DD, DataNascimento, GETDATE())/365.25 AS INT) as idade, email, senha, sexo, ativo FROM usuarios WHERE ativo = {0} AND nome like '%{1}%' ", ativo, nome).ToListAsync();
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