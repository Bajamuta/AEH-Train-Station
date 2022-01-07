using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Pages.Journey
{
    public class IndexModel : PageModel
    {
        private readonly TrainStation.Data.TrainStationContext _context;

        public IndexModel(TrainStation.Data.TrainStationContext context)
        {
            _context = context;
        }

        public IList<Models.Journey> Journey { get;set; }

        public async Task OnGetAsync()
        {
            Journey = await _context.Journeys
                .Include(j => j.DestinationPlace)
                .Include(j => j.Ride)
                .Include(j => j.StartingPlace)
                .Include(j => j.Status).ToListAsync();
        }
    }
}
