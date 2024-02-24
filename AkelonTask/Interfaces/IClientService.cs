using System.Collections.Generic;
using AkelonTask.Entities;

namespace AkelonTask.Interfaces
{
    public interface IClientService
    {
        bool ChangeContactPerson(Dictionary<int, ClientEntity> clientDictionary, string companyName,
            string newContactPerson, string filePath, string clientsSheetName);

        void UpdateClientInfo(Dictionary<int, ClientEntity> clientDictionary, string filePath, string clientsSheetName);

        void UpdateСlientsSheetName(string filePath, string clientsSheetName,
            Dictionary<int, ClientEntity> clientDictionary);
        
        
    }
}