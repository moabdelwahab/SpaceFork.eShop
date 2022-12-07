
using SpaceFork.eShop.Ordering.Core.Models;

namespace SpaceFork.eShop.Ordering.Core.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
