using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.API.Models
{
    public class PlaceBetResponse
    {
        public long TicketNumber { get; set; }
        public string ResponseMessage { get; set; }
    }
}
