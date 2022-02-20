using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainStation.Controllers;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Pages.Ride
{
    public class CreateModel : PageModel
    {
        private readonly TrainStationContext _context;
        private readonly CarController _carController;
        private readonly CarsController _carsController;
        private readonly ConductorsController _conductorsController;
        private readonly EmployeeController _employeeController;
        private readonly RideController _rideController;

        public CreateModel(TrainStationContext context)
        {
            _context = context;
            _carsController = new CarsController(context);
            _carController = new CarController(context);
            _employeeController = new EmployeeController(context);
            _conductorsController = new ConductorsController(context);
            _rideController = new RideController(context);
        }
        
        [BindProperty] public Models.Ride Ride { get; set; }

        [BindProperty] public int SelectedEngineId { get; set; }

        [BindProperty] public int SelectedDriverId { get; set; }
        
        
        public SelectList Engines { get; set; }
        public SelectList Employees { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Ride = new Models.Ride();
            Engines = new SelectList(_context.Engines, "ID", "Name");
            Employees = new SelectList(_context.Employees, "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                /*Ride.DriverId = SelectedDriverId;
                Ride.Driver = await _context.Employees.FirstAsync(e => e.ID == SelectedDriverId);
                Ride.EngineId = SelectedEngineId;
                Ride.Engine = await _context.Engines.FirstAsync(e => e.ID == SelectedEngineId);*/
                _context.Attach(Ride).State = EntityState.Added;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return RedirectToPage("./Index");
        }
    }
}
