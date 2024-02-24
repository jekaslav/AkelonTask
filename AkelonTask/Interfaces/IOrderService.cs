using System.Collections.Generic;
using AkelonTask.Entities;

namespace AkelonTask.Interfaces
{
    public interface IOrderService
    {
        void FindTopCustomerByOrders(List<OrderEntity> orderList,
            Dictionary<int, ClientEntity> clientDictionary);

        List<ClientEntity> GetTopCustomerByOrders(List<OrderEntity> orders, int year, int month,
            Dictionary<int, ClientEntity> clientDictionary);

    }
}