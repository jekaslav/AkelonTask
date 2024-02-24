using System;
using System.Collections.Generic;
using System.Linq;
using AkelonTask.Entities;
using ClosedXML.Excel;

namespace AkelonTask.Services
{
    public class ClientService
    {
        public static bool ChangeContactPerson(Dictionary<int, ClientEntity> clientDictionary, string companyName, string newContactPerson)
        {
            var client = clientDictionary.Values.FirstOrDefault(x =>
                string.Equals(x.Name, companyName, StringComparison.OrdinalIgnoreCase));

            if (client != null)
            {
                client.ContactPerson = newContactPerson;
                return true;
            }

            return false;
        }
        
        public static void UpdateClientInfo(Dictionary<int, ClientEntity> clientDictionary)
        {
            Console.WriteLine("Введите название организации клиента:");
            var companyName = Console.ReadLine();

            Console.WriteLine("Введите ФИО нового контактного лица:");
            var newContactPerson = Console.ReadLine();
            

            var success = ChangeContactPerson(clientDictionary, companyName, newContactPerson);
            ResultPrintService.PrintContactPersonChangeResult(success, companyName, newContactPerson);
        }
    }
}