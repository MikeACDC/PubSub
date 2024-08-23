using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PubSub.Models
{
    public class BankAccount
    {
        public int AccountID { get; set; }
        public float Deposit { get; set; }
    }
}
