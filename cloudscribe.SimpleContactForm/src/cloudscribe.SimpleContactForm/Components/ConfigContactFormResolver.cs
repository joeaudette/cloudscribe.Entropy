using cloudscribe.SimpleContactForm.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace cloudscribe.SimpleContactForm.Components
{
    public class ConfigContactFormResolver : IContactFormResolver
    {
        public ConfigContactFormResolver(IOptions<ContactForm> contactFormAccessor)
        {
            form = contactFormAccessor.Value;
        }

        private ContactForm form;

        public Task<ContactForm> GetCurrentContactForm()
        {
            return Task.FromResult(form);
        }
    }
}
