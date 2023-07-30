using BetForGateway.Dtos;
using BetForGateway.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BetForGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BetController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public BetController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        [Route("TryGetCurrentTour")]
        public async Task<IActionResult> GetExternalData()
        {
            try
            {
                _httpClient.BaseAddress = new Uri("https://localhost:7237/api/");

                var response = await _httpClient.GetAsync("Tour/GetTourInfo");

                if (response.IsSuccessStatusCode == true)
                {
                    var data = await response.Content.ReadFromJsonAsync<CurrentTourResponse>();

                    if (data != null)
                    {
                        return Ok(data);
                    }
                }

                return BadRequest();
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("TryBet")]
        public async Task<IActionResult> PostExternalData([FromBody] BetRequest request)
        {
            try
            {
                Guard.NotNull<BetRequest>(request);

                _httpClient.BaseAddress = new Uri("https://localhost:7237/api/");

                var response = await _httpClient.PostAsJsonAsync("Client/CreateBet", request);

                if (response.IsSuccessStatusCode == true)
                {
                    var data = await response.Content.ReadFromJsonAsync<TryBetResponse>();

                    if (data != null)
                    {
                        return Ok(data);
                    }
                }

                return BadRequest(new TryBetResponse
                {
                    IsCreated = false,
                    ResponseMessage = "Bet is not created!"
                });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
