using System.Collections.Generic;
using AkelonTask.Entities;

namespace AkelonTask.Interfaces
{
    public interface IProductService
    {
        void SearchProductAndPrintOrders(Dictionary<int, ProductEntity> productDictionary,
            Dictionary<int, ClientEntity> clientDictionary, IEnumerable<OrderEntity> orderList);
    }
}