namespace AuthorizationWithPermission.API.Entities
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set;}
    }
}
