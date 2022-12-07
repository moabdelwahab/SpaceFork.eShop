using MediatR;
using SpaceFork.eShop.Ordering.Core.DataToTransfer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Ordering.Application.Features.Orders.Queries
{
    public class GetOrdersListQuery : IRequest<List<Order>>
    {
        public string UserName { get; set; }
        public GetOrdersListQuery(string username)
        {
            UserName = username ?? throw new ArgumentNullException(nameof(username));
        }

    }
}
