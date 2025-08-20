using BaseArchitecture.Domain.Shared.BaseEntity.Implementations;
namespace BaseArchitecture.Domain.Entities
{
    public class Product : BaseEntityWithName
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public ICollection<OrderDetails>? OrderDetails { get; set; }
    }
}
