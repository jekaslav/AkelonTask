using System.Collections.Generic;
using AkelonTask.Entities;

namespace AkelonTask.Interfaces
{
    public interface IFileReaderService
    {
        (Dictionary<int, ProductEntity>, Dictionary<int, ClientEntity>, List<OrderEntity>) ReadLinkedTables(string filePath,
            string productsSheetName, string clientsSheetName, string ordersSheetName);
        
        
    }
}