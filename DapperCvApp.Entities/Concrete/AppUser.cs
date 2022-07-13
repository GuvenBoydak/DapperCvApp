namespace DapperCvApp.Entities
{
    [Dapper.Contrib.Extensions.Table("AppUsers")]
    public class AppUser:BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

    }
}
