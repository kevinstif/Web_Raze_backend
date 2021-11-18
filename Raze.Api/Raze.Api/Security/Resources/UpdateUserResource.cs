namespace Raze.Api.Security.Resources
{
    public class UpdateUserResource
    {
        public string Name { get; set; }
        public string ImgProfile { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public  string Password { get; set; }
        public bool Premium { get; set; }
        public int InterestId { get; set; }
        public int ProfessionId { get; set; }
    }
}