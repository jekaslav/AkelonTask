using System;
using System.Collections.Generic;
using System.Linq;
using AkelonTask.Entities;
using ClosedXML.Excel;

namespace AkelonTask.Services
{
    public class ClientService
    {
        public static bool ChangeContactPerson(Dictionary<int, ClientEntity> clientDictionary, string companyName, string newContactPerson, string filePath, string clientsSheetName)
        {
            var client = clientDictionary.Values.FirstOrDefault(x =>
                string.Equals(x.Name, companyName, StringComparison.OrdinalIgnoreCase));

            if (client != null)
            {
                client.ContactPerson = newContactPerson;
                UpdateСlientsSheetName(filePath, clientsSheetName, clientDictionary);
                return true;
            }

            return false;
        }

        
        public static void UpdateClientInfo(Dictionary<int, ClientEntity> clientDictionary, string filePath, string clientsSheetName)
        {
            Console.WriteLine("Введите название организации клиента:");
            var companyName = Console.ReadLine();

            Console.WriteLine("Введите ФИО нового контактного лица:");
            var newContactPerson = Console.ReadLine();

            var success = ChangeContactPerson(clientDictionary, companyName, newContactPerson, filePath, clientsSheetName);
            ResultPrintService.PrintContactPersonChangeResult(success, companyName, newContactPerson);
        }

        
        public static void UpdateСlientsSheetName(string filePath, string clientsSheetName, Dictionary<int, ClientEntity> clientDictionary)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var clientsWorksheet = workbook.Worksheet(clientsSheetName);

                foreach (var client in clientDictionary.Values)
                {
                    var row = clientsWorksheet.Rows().FirstOrDefault(r => 
                    {
                        var cellValue = r.Cell(1).GetString();
                        return !string.IsNullOrEmpty(cellValue) && cellValue == client.Id.ToString();
                    });

                    if (row != null)
                    {
                        row.Cell(4).Value = client.ContactPerson;
                    }
                }
                
                workbook.Save();
            }
        }
    }
}