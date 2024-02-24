using System;
using System.Collections.Generic;
using System.Linq;
using AkelonTask.Entities;

namespace AkelonTask.Services
{
    public class ResultPrintService
    {
        public static void PrintAllProducts(Dictionary<int, ProductEntity> productDictionary)
        {
            Console.WriteLine("Список всех товаров:");
            foreach (var product in productDictionary.Values)
            {
                Console.WriteLine($"ID: {product.Id}, Название: {product.Name}, Единица измерения: {product.Unit}, Цена: {product.Price}");
            }
        }

        public static void PrintAllClients(Dictionary<int, ClientEntity> clientDictionary)
        {
            Console.WriteLine("Список всех клиентов:");
            foreach (var client in clientDictionary.Values)
            {
                Console.WriteLine($"ID: {client.Id}, Название организации: {client.Name}, Адрес: {client.Address}, Контактное лицо: {client.ContactPerson}");
            }
        }

        public static void PrintOrdersForProduct(ProductEntity foundProduct, List<OrderEntity> ordersForProduct, Dictionary<int, ClientEntity> clientDictionary)
        {
            Console.WriteLine($"Информация о клиентах, заказавших товар '{foundProduct.Name}':");

            if (ordersForProduct.Any())
            {
                foreach (var order in ordersForProduct)
                {
                    var client = clientDictionary.GetValueOrDefault(order.ClientId);
                    if (client != null)
                    {
                        Console.WriteLine($"Клиент: {client.Name}");
                        Console.WriteLine($"Количество товара: {order.Quantity}");
                        Console.WriteLine($"Цена за единицу: {foundProduct.Price}");
                        Console.WriteLine($"Дата заказа: {order.OrderDate}");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Для товара '{foundProduct.Name}' нет заказов.");
            }
        }

        public static void PrintContactPersonChangeResult(bool success, string companyName, string newContactPerson)
        {
            if (success)
            {
                Console.WriteLine($"Контактное лицо организации '{companyName}' успешно изменено на '{newContactPerson}'.");
            }
            else
            {
                Console.WriteLine($"Клиент с названием организации '{companyName}' не найден.");
            }
        }

        public static void PrintTopCustomerByOrders(List<ClientEntity> topCustomers)
        {
            if (topCustomers.Any())
            {
                Console.WriteLine("Золотые клиенты:");
                foreach (var customer in topCustomers)
                {
                    Console.WriteLine($"ID: {customer.Id}, Название организации: {customer.Name}, Количество заказов: {customer.OrderCount}");
                }
            }
            else
            {
                Console.WriteLine("Золотые клиенты не найдены.");
            }
        }
    }
}