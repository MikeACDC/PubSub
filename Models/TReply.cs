using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub.Models
{
    public  class TReply
    {
        public string ReplyBody { get; set; } = string.Empty;
        public bool Success { get; set; }
    }
}
