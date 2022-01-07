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
    public class DeleteModel : PageModel
    {
        private readonly TrainStation.Data.TrainStationContext _context;

        public DeleteModel(TrainStation.Data.TrainStationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Journey Journey { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Journey = await _context.Journeys
                .Include(j => j.DestinationPlace)
                .Include(j => j.Ride)
                .Include(j => j.StartingPlace)
                .Include(j => j.Status).FirstOrDefaultAsync(m => m.ID == id);

            if (Journey == null)
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

            Journey = await _context.Journeys.FindAsync(id);

            if (Journey != null)
            {
                _context.Journeys.Remove(Journey);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
