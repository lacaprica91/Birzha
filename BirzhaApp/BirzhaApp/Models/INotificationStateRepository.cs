using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public interface INotificationStateRepository
    {
        IQueryable<NotificationState> NotificationStates { get; }
    }
}
