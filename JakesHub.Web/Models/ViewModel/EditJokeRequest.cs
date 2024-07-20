namespace JakesHub.Web.Models.ViewModel
{
    public class EditJokeRequest
    {
        public Guid Id { get; set; }
        public string JokeQuestion { get; set; }
        public string JokeAnswer { get; set; }
    }
}
