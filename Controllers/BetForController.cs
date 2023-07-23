using Microsoft.AspNetCore.Mvc;
using BetForGateway.Dtos;

namespace YourWebApiNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalApiController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ExternalApiController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetExternalData()
        {
            try
            {
                _httpClient.BaseAddress = new Uri("https://localhost:7237/api/");

                var response = await _httpClient.GetAsync("Tour/GetTourInfo");

                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadFromJsonAsync<object>();

                return Ok(data);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostExternalData([FromBody] BetRequest request)
        {
            try
            {
                _httpClient.BaseAddress = new Uri("https://localhost:7237/api/");

                var response = await _httpClient.PostAsJsonAsync("Tour/TryBetForCurrentTour", request);

                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadFromJsonAsync<object>();

                return Ok(data);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
