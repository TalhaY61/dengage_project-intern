using System;
using System.Collections.Generic;
using System.Text;

namespace DengageDemoApp.Contract.Response
{
    internal class ProductResponse
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int category_ID { get; set; }
    }
}
