using Microsoft.AspNetCore.Mvc;
using TrainStation.Data;

namespace TrainStation.Controllers
{
    public class TicketController: Controller
    {
        private readonly TrainStationContext _context;

        public TicketController(TrainStationContext context)
        {
            _context = context;
        }
    }
}