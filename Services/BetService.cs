using BetForGateway.Helpers;
using BetForGateway.Dtos;

namespace BetForGateway.Services
{
    public class BetService : IBetService
    {
        private readonly HttpClient httpClient;
        public BetService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<CurrentTourResponse> TryGetCurrentTour()
        {
            httpClient.BaseAddress = new Uri("https://localhost:7237/api/");

            var response = await httpClient.GetAsync("Tour/GetTourInfo");

            if (response.IsSuccessStatusCode == true)
            {
                var data = await response.Content.ReadFromJsonAsync<CurrentTourResponse>();

                if (data != null)
                {
                    return data;
                }
            }

            return null;
        }

        public async Task<TryBetResponse> TryBet(BetRequest request)
        {
            Guard.NotNull<BetRequest>(request);

            httpClient.BaseAddress = new Uri("https://localhost:7237/api/");

            var response = await httpClient.PostAsJsonAsync("Client/CreateBet", request);

            if (response.IsSuccessStatusCode == true)
            {
                var data = await response.Content.ReadFromJsonAsync<TryBetResponse>();

                if (data != null)
                {
                    return data;
                }
            }

            return new TryBetResponse
            {
                IsCreated = false,
                ResponseMessage = "Bet is not created!"
            };
        }

    }
}