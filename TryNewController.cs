// using BetForGateway.Helpers;
// using BetForGateway.Services;
// using BetForGateway.Dtos;
// using Microsoft.AspNetCore.Mvc;

// namespace BetForGateway.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class BetForController : ControllerBase
//     {
//         private readonly BetService service;

//         public BetForController(BetService service)
//         {
//             this.service = service;
//         }

//         [HttpGet]
//         [Route("TryGetCurrentTour")]
//         public async Task<IActionResult> TryGetCurrentTour()
//         {
//             try
//             {
//                 var result = await service.TryGetCurrentTour();

//                 if (result != null)
//                 {
//                     return Ok(result);
//                 }

//                 return BadRequest();
//             }
//             catch (HttpRequestException ex)
//             {
//                 return StatusCode(500, $"Error: {ex.Message}");
//             }
//         }

//         [HttpPost]
//         [Route("TryBet")]
//         public async Task<IActionResult> TryBet([FromBody] BetRequest request)
//         {
//             try
//             {
//                 Guard.NotNull<BetRequest>(request);

//                 var result = await service.TryBet(request);

//                 if (result != null)
//                 {
//                     return Ok(result);
//                 }

//                 return BadRequest("Bet time has passed.Try again later!");
//             }
//             catch (HttpRequestException ex)
//             {
//                 return StatusCode(500, $"Error: {ex.Message}");
//             }
//         }
//     }
// }
