namespace BetForGateway.Helpers
{
    public static class Guard
    {
        public static void NotNull<T>(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}