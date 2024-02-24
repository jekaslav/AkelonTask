using System;

namespace AkelonTask.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public string OrderNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}