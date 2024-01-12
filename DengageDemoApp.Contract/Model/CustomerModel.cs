using System;
using System.Collections.Generic;
using System.Text;

namespace DengageDemoApp.Contract.Model
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string phonenumber { get; set; }
        public string createdBy { get; set; }
        public DateTime createdAt { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
