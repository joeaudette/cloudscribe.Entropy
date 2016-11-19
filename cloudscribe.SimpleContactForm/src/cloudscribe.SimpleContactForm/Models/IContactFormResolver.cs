using System.Threading.Tasks;

namespace cloudscribe.SimpleContactForm.Models
{
    public interface IContactFormResolver
    {
        Task<ContactForm> GetCurrentContactForm();
    }
}
