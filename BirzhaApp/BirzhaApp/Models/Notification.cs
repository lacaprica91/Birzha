using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; } //FK - recipient
        public int NotificationStateId { get; set; } //FK for not. state
        public string Url { get; set; }
        public string Message { get; set; }
        public DateTime ReadDate { get; set; }
    }
}
