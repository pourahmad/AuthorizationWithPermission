namespace AuthorizationWithPermission.API.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<OrderProduct> orderProducts { get; set; }
    }
}
