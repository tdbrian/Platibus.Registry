using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Platibus.Registry.SampleWebapp.Models;

namespace Platibus.Registry.SampleWebapp.Pages
{
    public class AddUserInputs
    {
        [Required]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        public string Email { get; set; }

        public SecureTideServiceType SecureTideType { get; set; }
    }

    public class IndexModel : PageModel
    {
        private readonly IBus _bus;

        [BindProperty]
        public AddUserInputs AddUserInputs { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool? SaveSuccess { get; set; }

        public IndexModel(IBus bus)
        {
            _bus = bus;
        }

        public void OnGet()
        {
            AddUserInputs = new AddUserInputs { SecureTideType = SecureTideServiceType.Standard };
        }

        public async Task<ActionResult> OnPostAddAsync()
        {
            await _bus.Send(new AddUserCommand { Username = AddUserInputs.Username, SecureTideType = AddUserInputs.SecureTideType, Email = AddUserInputs.Email });
            return RedirectToPage(new { SaveSuccess = true });
        }
    }
}
