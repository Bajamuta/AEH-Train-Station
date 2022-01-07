using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Pages.Journey
{
    public class EditModel : PageModel
    {
        private readonly TrainStation.Data.TrainStationContext _context;

        public EditModel(TrainStation.Data.TrainStationContext context)
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
            ViewData["DestinationPlaceId"] = new SelectList(_context.Places, "ID", "Name");
            ViewData["RideId"] = new SelectList(_context.Rides, "ID", "Name");
            ViewData["StartingPlaceId"] = new SelectList(_context.Places, "ID", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Journey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JourneyExists(Journey.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JourneyExists(int id)
        {
            return _context.Journeys.Any(e => e.ID == id);
        }
    }
}
