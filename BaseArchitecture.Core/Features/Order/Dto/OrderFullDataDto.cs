using static BaseArchitecture.Domain.Enums.EnumExtensions;

namespace BaseArchitecture.Core.Features.Orders.Dto
{
    public class OrderFullDataDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = OrderStatus.Pending.ToString();
        public int StatusCode { get; set; } = (int)OrderStatus.Pending;
        public int TotalPrice { get; set; }
        public int CustomerId { get; set; }
    }
}
