namespace MealOrdering.Shared.DTO
{
    public class OrderItemDTO
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid OrderId { get; set; }
        public string Description { get; set; }

        public string CreatedUserFullName { get; set; }
        public string OrderName { get; set; }
    }
}
