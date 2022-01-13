using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TrainStation.Controllers;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Pages.Ride
{
    public class EditModel : PageModel
    {
        private readonly TrainStation.Data.TrainStationContext _context;
        private readonly CarsController _carsController;

        public EditModel(TrainStation.Data.TrainStationContext context)
        {
            _context = context;
            _carsController = new CarsController(context);
        }

        [BindProperty]
        public Models.Ride Ride { get; set; }
        public Models.Engine Engine { get; set; }
        public SelectList Engines { get; set; }
        public Models.Employee Driver { get; set; }
        public SelectList Employees { get; set; }

        public List<Cars> ListRideCars { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //TODO controller
            Ride = await _context.Rides
                .Include(r => r.Driver)
                .Include(r => r.Engine)
                .Include(r => r.Cars)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Ride == null)
            {
                return NotFound();
            }

            ListRideCars = await _carsController.GetAllRideCars();

            //TODO controller
            Engines = new SelectList(_context.Engines, "ID", "Name");
            Employees = new SelectList(_context.Employees, "ID", "Name");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("OnPostAsync");
            
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
