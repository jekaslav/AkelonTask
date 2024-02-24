using System;
using System.Collections.Generic;
using System.IO;
using AkelonTask.Entities;
using AkelonTask.Interfaces;
using ClosedXML.Excel;

namespace AkelonTask.Services
{
    public class FileReaderService : IFileReaderService
    {
        public (Dictionary<int, ProductEntity>, Dictionary<int, ClientEntity>, List<OrderEntity>) ReadLinkedTables(string filePath, 
            string productsSheetName, string clientsSheetName, string ordersSheetName)
        {
            var productDictionary = new Dictionary<int, ProductEntity>();
            var clientDictionary = new Dictionary<int, ClientEntity>();
            var orderList = new List<OrderEntity>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл не найден: {filePath}");
                return (productDictionary, clientDictionary, orderList);
            }


                // Чтение Товаров
                using (var workbook = new XLWorkbook(filePath))
                {
                    var productsWorksheet = workbook.Worksheet(productsSheetName);

                    var currentRow = 2;
                    while (!productsWorksheet.Cell(currentRow, 1).IsEmpty())
                    {
                        var productId = productsWorksheet.Cell(currentRow, 1).GetValue<int>();
                        var productName = productsWorksheet.Cell(currentRow, 2).GetValue<string>();
                        var unit = productsWorksheet.Cell(currentRow, 3).GetValue<string>();
                        var price = productsWorksheet.Cell(currentRow, 4).GetValue<decimal>();

                        var product = new ProductEntity
                        {
                            Id = productId,
                            Name = productName,
                            Unit = unit,
                            Price = price
                        };

                        productDictionary.Add(productId, product);
                        currentRow++;
                    }
                }

                // Чтение Клиентов
                using (var workbook = new XLWorkbook(filePath))
                {
                    var clientsWorksheet = workbook.Worksheet(clientsSheetName);

                    var currentRow = 2;
                    while (!clientsWorksheet.Cell(currentRow, 1).IsEmpty())
                    {
                        var clientId = clientsWorksheet.Cell(currentRow, 1).GetValue<int>();
                        var clientName = clientsWorksheet.Cell(currentRow, 2).GetValue<string>();
                        var address = clientsWorksheet.Cell(currentRow, 3).GetValue<string>();
                        var contactPerson = clientsWorksheet.Cell(currentRow, 4).GetValue<string>();

                        var client = new ClientEntity
                        {
                            Id = clientId,
                            Name = clientName,
                            Address = address,
                            ContactPerson = contactPerson
                        };

                        clientDictionary.Add(clientId, client);
                        currentRow++;
                    }
                }

                // Чтение Заявок
                using (var workbook = new XLWorkbook(filePath))
                {
                    var ordersWorksheet = workbook.Worksheet(ordersSheetName);

                    var currentRow = 2;
                    while (!ordersWorksheet.Cell(currentRow, 1).IsEmpty())
                    {
                        var orderId = ordersWorksheet.Cell(currentRow, 1).GetValue<int>();
                        var productId = ordersWorksheet.Cell(currentRow, 2).GetValue<int>();
                        var clientId = ordersWorksheet.Cell(currentRow, 3).GetValue<int>();
                        var orderNumber = ordersWorksheet.Cell(currentRow, 4).GetValue<string>();
                        var quantity = ordersWorksheet.Cell(currentRow, 5).GetValue<int>();
                        var orderDate = ordersWorksheet.Cell(currentRow, 6).GetDateTime();

                        var order = new OrderEntity
                        {
                            Id = orderId,
                            ProductId = productId,
                            ClientId = clientId,
                            OrderNumber = orderNumber,
                            Quantity = quantity,
                            OrderDate = orderDate
                        };

                        orderList.Add(order);
                        currentRow++;
                    }
                }

            return (productDictionary, clientDictionary, orderList);
        }
    }
}


