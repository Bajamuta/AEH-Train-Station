using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Pages.Permission
{
    public class IndexModel : PageModel
    {
        private readonly TrainStation.Data.TrainStationContext _context;

        public IndexModel(TrainStation.Data.TrainStationContext context)
        {
            _context = context;
        }

        public IList<Models.Permission> Permission { get;set; }

        public async Task OnGetAsync()
        {
            Permission = await _context.Permission.ToListAsync();
        }
    }
}
