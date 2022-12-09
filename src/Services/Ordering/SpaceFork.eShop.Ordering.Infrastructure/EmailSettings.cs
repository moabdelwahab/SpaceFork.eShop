using SpaceFork.eShop.Ordering.Core.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Ordering.Infrastructure
{
    public class EmailSettings : IEmailSettings
    {
        public string ApiKey { get; set ; }
        public string Server { get; set; }
        public string Server_Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
