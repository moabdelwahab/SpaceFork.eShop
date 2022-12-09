using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Ordering.Core.Contracts.Infrastructure
{
    public interface IEmailSettings
    {
        string ApiKey { get; set; }
        string Server { get; set; }
        string Server_Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string FromAddress { get; set; }

        string FromName { get; set; }

    }
}
