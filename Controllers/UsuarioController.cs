using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itbit_asp_net_core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace itbit_asp_net_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UsuarioModel>> ObterTodos(){
            return Ok();
        }
    }
}