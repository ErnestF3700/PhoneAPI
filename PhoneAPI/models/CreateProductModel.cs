namespace PhoneAPI.models
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductStatus Status {  get; set; }
}
}
