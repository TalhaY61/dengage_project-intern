using System;
using System.Collections.Generic;
using System.Text;

namespace DengageDemoApp.Contract.Model
{
    public class OrdersModel
    {
        public int ID { get; set; }
        public string status { get; set; }
        public int product_ID { get; set; }
        public int customer_ID { get; set; }
        public string createdBy { get; set; }
        public DateTime createdAt { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
