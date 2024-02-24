using System;
using System.Collections.Generic;
using System.Linq;
using AkelonTask.Entities;
using AkelonTask.Interfaces;

namespace AkelonTask.Services
{
    public class ProductService : IProductService
    {
        private readonly ResultPrinterService _resultPrinter;

        public ProductService(ResultPrinterService resultPrinter)
        {
            _resultPrinter = resultPrinter;
        }

        public void SearchProductAndPrintOrders(Dictionary<int, ProductEntity> productDictionary,
            Dictionary<int, ClientEntity> clientDictionary, IEnumerable<OrderEntity> orderList)
        {
            Console.WriteLine("Введите наименование товара для поиска:");
            var productName = Console.ReadLine();

            var foundProduct = productDictionary.Values.FirstOrDefault(p =>
                string.Equals(p.Name, productName, StringComparison.OrdinalIgnoreCase));

            if (foundProduct != null)
            {
                var ordersForProduct = orderList.Where(x => x.ProductId == foundProduct.Id).ToList();
                _resultPrinter.PrintOrdersForProduct(foundProduct, ordersForProduct, clientDictionary);
            }
            else
            {
                Console.WriteLine("Товар не найден.");
            }
        }
    }


}