namespace Platibus.Registry.SampleWebapp.Models
{
    public class AddUserCommand
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public SecureTideServiceType SecureTideType { get; set; }
    }
}
