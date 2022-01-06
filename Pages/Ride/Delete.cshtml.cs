using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Pages.Ride
{
    public class DeleteModel : PageModel
    {
        private readonly TrainStation.Data.TrainStationContext _context;

        public DeleteModel(TrainStation.Data.TrainStationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Ride Ride { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ride = await _context.Rides
                .Include(r => r.Driver)
                .Include(r => r.Engine).FirstOrDefaultAsync(m => m.ID == id);

            if (Ride == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ride = await _context.Rides.FindAsync(id);

            if (Ride != null)
            {
                _context.Rides.Remove(Ride);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
