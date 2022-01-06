using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Pages.Ride
{
    public class CreateModel : PageModel
    {
        private readonly TrainStation.Data.TrainStationContext _context;

        public CreateModel(TrainStation.Data.TrainStationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DriverId"] = new SelectList(_context.Employees, "ID", "ID");
        ViewData["EngineId"] = new SelectList(_context.Engines, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Models.Ride Ride { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rides.Add(Ride);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
