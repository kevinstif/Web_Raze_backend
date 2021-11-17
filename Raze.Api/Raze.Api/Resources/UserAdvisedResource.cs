namespace Raze.Api.Resources
{
    public class UserAdvisedResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public  string Password { get; set; }
        public int Age { get; set; }
        public bool Premium { get; set; }
        public string Type { get; set; }
        public int Mood { get; set; }
    }
}