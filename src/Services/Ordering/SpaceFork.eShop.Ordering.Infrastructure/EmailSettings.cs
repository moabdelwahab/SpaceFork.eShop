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
        public string ApiKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Server { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SMTP_ServerIP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FromAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FromName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
