namespace Core.Models.DTO
{
    public class NewUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public int PasswordHash { get; set; }
        public DateTime BirthDate { get; set; }
        public int PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}