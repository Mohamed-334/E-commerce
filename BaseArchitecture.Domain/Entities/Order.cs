using BaseArchitecture.Domain.Shared.BaseEntity.Implementations;
using System.ComponentModel.DataAnnotations.Schema;
using static BaseArchitecture.Domain.Enums.EnumExtensions;
namespace BaseArchitecture.Domain.Entities
{
    public class Order : BaseEntity
    {
        // CreatedAt Property Exists in BaseEntity
        public string Status { get; set; } = OrderStatus.Pending.ToString();
        public int StatusCode { get; set; } = (int)OrderStatus.Pending;
        public int TotalPrice { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public User? Customer { get; set; }
        public ICollection<OrderDetails>? OrderDetails { get; set; }
    }
}
