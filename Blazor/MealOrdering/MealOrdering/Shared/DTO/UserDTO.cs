namespace MealOrdering.Shared.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMailAdress { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}