namespace Raze.Api.Security.Domain.Services.Communication
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgProfile { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string JwtToken { get; set; }
        public int InterestId { get; set; }
        public string UserType { get; set; }
        public string Username { get; set; }
        public bool Premium { get; set; }
        public int ProfessionId { get; set; }
    }
}