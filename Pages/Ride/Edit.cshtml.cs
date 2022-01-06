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

namespace TrainStation.Pages.Ride
{
    public class EditModel : PageModel
    {
        private readonly TrainStation.Data.TrainStationContext _context;

        public EditModel(TrainStation.Data.TrainStationContext context)
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
           ViewData["DriverId"] = new SelectList(_context.Employees, "ID", "ID");
           ViewData["EngineId"] = new SelectList(_context.Engines, "ID", "ID");
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

            _context.Attach(Ride).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RideExists(Ride.ID))
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

        private bool RideExists(int id)
        {
            return _context.Rides.Any(e => e.ID == id);
        }
    }
}
