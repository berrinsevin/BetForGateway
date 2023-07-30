using BetForGateway.Dtos;

namespace BetForGateway.Services
{
    public interface IBetService
    {
        Task<CurrentTourResponse> TryGetCurrentTour();
        Task<TryBetResponse> TryBet(BetRequest request);
    }
}