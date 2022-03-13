namespace MealOrdering.Server.Data.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid OrderId { get; set; }
        public string Description { get; set; }

        public virtual User CreatedUser { get; set; }
        public virtual Order Order { get; set; }
    }
}
