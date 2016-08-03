using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Body { get; set; }
        public DateTime CreatedUtc { get; set; }

    }
}
