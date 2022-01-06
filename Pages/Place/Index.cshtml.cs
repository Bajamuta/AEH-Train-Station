using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Pages.Place
{
    public class IndexModel : PageModel
    {
        private readonly TrainStation.Data.TrainStationContext _context;

        public IndexModel(TrainStation.Data.TrainStationContext context)
        {
            _context = context;
        }

        public IList<Models.Place> Place { get;set; }

        public async Task OnGetAsync()
        {
            Place = await _context.Places.ToListAsync();
        }
    }
}
