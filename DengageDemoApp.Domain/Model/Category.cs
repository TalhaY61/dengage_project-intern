using System;

namespace DengageDemoApp.Domain.Model
{
    public class Category
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string createdBy { get; set; }
        public DateTime createdAt { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
