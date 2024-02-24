using System;
using AkelonTask.Services;

namespace AkelonTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу Excel:");
            var filePath = Console.ReadLine();

            Console.WriteLine("Введите имя листа 1 (Товары):");
            var productsSheetName = Console.ReadLine();

            Console.WriteLine("Введите имя листа 2 (Клиенты):");
            var clientsSheetName = Console.ReadLine();

            Console.WriteLine("Введите имя листа 3 (Заявки):");
            var ordersSheetName = Console.ReadLine();

            var (productDictionary, clientDictionary, orderList) =
                FileReaderService.ReadLinkedTables(filePath, productsSheetName, clientsSheetName, ordersSheetName);

            var exit = false;
            while (!exit)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Вывод всех товаров");
                Console.WriteLine("2. Вывод всех клиентов");
                Console.WriteLine("3. Поиск товара и информация о клиентах");
                Console.WriteLine("4. Изменить данные клиента");
                Console.WriteLine("5. Определение золотого клиента");
                Console.WriteLine("6. Выход");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ResultPrintService.PrintAllProducts(productDictionary);
                        break;
                    case "2":
                        ResultPrintService.PrintAllClients(clientDictionary);
                        break;
                    case "3":
                        ProductService.SearchProductAndPrintOrders(productDictionary, clientDictionary, orderList);
                        break;
                    case "4":
                        ClientService.UpdateClientInfo(clientDictionary, filePath, clientsSheetName);
                        break;
                    case "5":
                        OrderService.FindTopCustomerByOrders(orderList, clientDictionary);
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
            Console.WriteLine("Работа программы завершена.");
        }
    }
}
