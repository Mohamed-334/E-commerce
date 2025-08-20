namespace BaseArchitecture.Domain.Enums
{
    public static class EnumExtensions
    {
        public enum OrderStatus
        {
            Pending = 1,
            Processing = 2,
            Delivered = 3,
            Cancelled = 4
        }
    }
}
