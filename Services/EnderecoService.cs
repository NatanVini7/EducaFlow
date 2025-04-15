using EducaFlow.Context;
using EducaFlow.Models;
using EducaFlow.Dtos;
using Microsoft.Extensions.Caching.Memory;

namespace EducaFlow.Services
{
    public class EnderecoService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly AlunoContext _context;

        public EnderecoService(HttpClient httpClient, IMemoryCache cache, AlunoContext context)
        {
            _httpClient = httpClient;
            _cache = cache;
            _context = context;
        }

        public async Task<List<EstadoDto>> ObterEstadosAsync()
        {
            if (!_cache.TryGetValue("estados", out List<EstadoDto> estados))
            {
                var url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
                estados = await _httpClient.GetFromJsonAsync<List<EstadoDto>>(url) ?? new List<EstadoDto>();
                estados = estados.OrderBy(e => e.Nome).ToList();

                _cache.Set("estados", estados, TimeSpan.FromHours(1));
            }

            return estados;
        }

        public async Task<List<MunicipioDto>> ObterCidadesPorUfAsync(string uf)
        {
            var cacheKey = $"cidades_{uf.ToUpper()}";

            if (!_cache.TryGetValue(cacheKey, out List<MunicipioDto> cidades))
            {
                var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{uf}/municipios";
                cidades = await _httpClient.GetFromJsonAsync<List<MunicipioDto>>(url) ?? new List<MunicipioDto>();
                cidades = cidades.OrderBy(c => c.Nome).ToList();

                _cache.Set(cacheKey, cidades, TimeSpan.FromHours(1));
            }

            return cidades;
        }
    }
}
