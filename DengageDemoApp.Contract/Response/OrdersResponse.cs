using System;
using System.Collections.Generic;
using System.Text;

namespace DengageDemoApp.Contract.Response
{
    internal class OrdersResponse
    {
        public int ID { get; set; }
        public string status { get; set; }
        public int product_ID { get; set; }
        public int customer_ID { get; set; }
    }
}
