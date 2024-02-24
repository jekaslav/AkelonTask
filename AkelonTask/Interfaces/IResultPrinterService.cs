using System.Collections.Generic;
using AkelonTask.Entities;

namespace AkelonTask.Interfaces
{
    public interface IResultPrinterService
    {
        void PrintAllProducts(Dictionary<int, ProductEntity> productDictionary);

        void PrintAllClients(Dictionary<int, ClientEntity> clientDictionary);

        void PrintOrdersForProduct(ProductEntity foundProduct, List<OrderEntity> ordersForProduct,
            Dictionary<int, ClientEntity> clientDictionary);

        void PrintTopCustomerByOrders(List<ClientEntity> topCustomers);
    }
}