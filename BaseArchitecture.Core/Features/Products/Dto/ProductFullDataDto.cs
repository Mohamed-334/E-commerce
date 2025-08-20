namespace BaseArchitecture.Core.Features.Products.Dto
{
    public class ProductFullDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? NameLocalization { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
