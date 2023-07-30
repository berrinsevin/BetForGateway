namespace BetForGateway.Dtos
{
    public class CurrentTourResponse
    {
        public long StartNumber { get; set; }
        public long EndNumber { get; set; }
        public DateTime TourStartTime { get; set; }
        public DateTime TourEndTime { get; set; }
    }
}
