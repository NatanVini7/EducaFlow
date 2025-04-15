using EducaFlow.Services;
using Microsoft.AspNetCore.Mvc;

namespace EducaFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        // GET: api/endereco/estados
        [HttpGet("estados")]
        public async Task<IActionResult> GetEstados()
        {
            var estados = await _enderecoService.ObterEstadosAsync();
            return Ok(estados);
        }

        // GET: api/endereco/estados/{uf}/cidades
        [HttpGet("estados/{uf}/cidades")]
        public async Task<IActionResult> GetCidades(string uf)
        {
            var cidades = await _enderecoService.ObterCidadesPorUfAsync(uf);
            return Ok(cidades);
        }
    }
}
