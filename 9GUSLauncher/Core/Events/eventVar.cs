using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9GUSLauncher.Core.Events
{
    public class eventVar
    {
        public string eventName { get; set; }
        public DateTime eventDate { get; set; }
        public string eventMap { get; set; }
        public string eventType { get; set; }
        public string eventDescription { get; set; }
        public int eventMinPlayers { get; set; }
        public string[] eventMods { get; set; }
        public string[] eventSubscribers { get; set; }
    }
}
