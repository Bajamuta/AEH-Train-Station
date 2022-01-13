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
using Microsoft.EntityFrameworkCore.Diagnostics;
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
        private readonly CarController _carController;
        private readonly EmployeeController _employeeController;
        private readonly EngineController _engineController;

        public EditModel(TrainStation.Data.TrainStationContext context)
        {
            _context = context;
            _carsController = new CarsController(context);
            _carController = new CarController(context);
            _employeeController = new EmployeeController(context);
            _engineController = new EngineController(context);
        }

        [BindProperty]
        public Models.Ride Ride { get; set; }
        [BindProperty]
        public int SelectedEngineId { get; set; }
        [BindProperty]
        public int SelectedCarId { get; set; }
        [BindProperty]
        public int SelectedDriverId { get; set; }
        public SelectList Engines { get; set; }
        public SelectList Employees { get; set; }
        public SelectList ListRideCars { get; set; }
        public SelectList ListAvailableCars { get; set; }
        public IEnumerable<Cars> TempCars { get; set; }
        public List<Models.Car> TempListCar { get; set; }

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
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            TempCars = _context.Cars
                .Include(c => c.Car)
                .Include(c => c.Ride)
                .Where(c => c.RideID == Ride.ID);

            if (Ride == null)
            {
                return NotFound();
            }

            TempListCar = new List<Models.Car>();

            foreach (Cars c in TempCars)
            {
                TempListCar.Add(c.Car);
            }

            ListRideCars = new SelectList(TempListCar, "ID", "Name");
            ListAvailableCars = new SelectList(_context.Car.Where(c => c.Available), "ID", "Name");
            Engines = new SelectList(_context.Engines, "ID", "Name");
            Employees = new SelectList(_context.Employees, "ID", "Name");
            return Page();
        }

        public IActionResult OnPostDelete()
        {
            try
            {
                _carsController.RemoveCarFromRide(SelectedCarId);
                _context.SaveChanges();
                _carController.MakeCarAvailable(SelectedCarId);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR", e);
            }
            Console.WriteLine("ON Delete ");
            SelectedCarId = 0;
            return RedirectToPage("Edit", Ride.ID);
        }
        
        public IActionResult OnPostAdd()
        {
            Console.WriteLine("ON Add " + SelectedCarId);
            try
            {
                _carsController.AddCarToRide(SelectedCarId, Ride.ID);
                _context.SaveChanges();
                _carController.MakeCarUnavailable(SelectedCarId);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR", e);
            }

            SelectedCarId = 0;
            return RedirectToPage("Edit", Ride.ID);
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

            try
            {
                Ride.DriverId = SelectedDriverId;
                Ride.Driver = await _context.Employees.FirstAsync(e => e.ID == SelectedDriverId);
                Ride.EngineId = SelectedEngineId;
                Ride.Engine = await _context.Engines.FirstAsync(e => e.ID == SelectedEngineId);
                _context.Attach(Ride).State = EntityState.Modified;
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
