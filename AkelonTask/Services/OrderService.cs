using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AkelonTask.Entities;
using AkelonTask.Interfaces;

namespace AkelonTask.Services
{
    public class OrderService : IOrderService
    {
        private readonly ResultPrinterService _resultPrinter;
        
        public OrderService(ResultPrinterService resultPrinter)
        {
            _resultPrinter = resultPrinter;
        }
        public void FindTopCustomerByOrders(List<OrderEntity> orderList,
            Dictionary<int, ClientEntity> clientDictionary)
        {
            Console.WriteLine("Введите год и месяц для определения золотого клиента (гггг мм):");
        
            var yearMonthInput = Console.ReadLine();
        
            if (DateTime.TryParseExact(yearMonthInput, "yyyy MM", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out var yearMonth))
            {
                var topCustomers =
                    GetTopCustomerByOrders(orderList, yearMonth.Year, yearMonth.Month, clientDictionary);
                _resultPrinter.PrintTopCustomerByOrders(topCustomers);
            }
            else
            {
                Console.WriteLine("Неверный формат ввода для года и месяца.");
            }
        }
        
        public List<ClientEntity> GetTopCustomerByOrders(List<OrderEntity> orders, int year, int month, Dictionary<int, ClientEntity> clientDictionary)
        {
            var filteredOrders = orders.Where(x => x.OrderDate.Year == year && x.OrderDate.Month == month).ToList();
            var customerOrdersCount = new Dictionary<int, int>();

            foreach (var order in filteredOrders)
            {
                if (customerOrdersCount.ContainsKey(order.ClientId))
                {
                    customerOrdersCount[order.ClientId]++;
                }
                else
                {
                    customerOrdersCount[order.ClientId] = 1;
                }
            }

            var topCustomersIds = customerOrdersCount.OrderByDescending(x => x.Value).Select(kvp => kvp.Key).Take(3).ToList();

            var topCustomers = new List<ClientEntity>();
            foreach (var clientId in topCustomersIds)
            {
                var customer = GetClientById(clientId, clientDictionary);
                if (customer != null)
                {
                    customer.OrderCount = customerOrdersCount[clientId];
                    topCustomers.Add(customer);
                }
            }

            return topCustomers;
        }

        private static ClientEntity GetClientById(int clientId, IReadOnlyDictionary<int, ClientEntity> clientDictionary)
        {
            if (clientDictionary.ContainsKey(clientId))
            {
                return clientDictionary[clientId];
            }
            else
            {
                return null;
            }
        }
    }
}