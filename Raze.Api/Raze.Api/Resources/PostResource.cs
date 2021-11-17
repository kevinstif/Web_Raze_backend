namespace Raze.Api.Resources
{
    public class PostResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public float Rate { get; set; }
        public int NumberOfRates { get; set; }
        public string UserType { get; set; }
        public int UserId { get; set; }
        public int InterestId { get; set; }
        public int TagId { get; set; }
        public UserResource User;
        public InterestResource Interest;
        public TagResource Tag;
    }
}