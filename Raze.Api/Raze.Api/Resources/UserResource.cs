namespace Raze.Api.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgProfile { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public  string Password { get; set; }
        public int Age { get; set; }
        public bool Premium { get; set; }
        public int ProfessionId { get; set; }
        public int InterestId { get; set; }
    }
}