using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainStation.Controllers;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Pages.Ride
{
    public class EditModel : PageModel
    {
        private readonly CarController _carController;
        private readonly CarsController _carsController;
        private readonly ConductorsController _conductorsController;
        private readonly TrainStationContext _context;
        private readonly EmployeeController _employeeController;

        public EditModel(TrainStationContext context)
        {
            _context = context;
            _carsController = new CarsController(context);
            _carController = new CarController(context);
            _employeeController = new EmployeeController(context);
            _conductorsController = new ConductorsController(context);
        }

        [BindProperty] public Models.Ride Ride { get; set; }

        [BindProperty] public int SelectedEngineId { get; set; }

        [BindProperty] public int SelectedCarId { get; set; }

        [BindProperty] public int SelectedDriverId { get; set; }

        [BindProperty] public int SelectedConductorId { get; set; }

        public SelectList Engines { get; set; }
        public SelectList Employees { get; set; }
        public SelectList ListRideCars { get; set; }
        public SelectList ListAvailableCars { get; set; }
        public SelectList ListAvailableConductors { get; set; }
        public SelectList ListRideConductors { get; set; }
        public List<Models.Employee> TempRideConductors { get; set; }
        public List<Models.Car> TempListCar { get; set; }
        public List<Models.Employee> TempListConductorsWithoutRide { get; set; }

        //TODO DRIVERS NOT EMPLOYEES
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Ride = await _context.Rides
                .Include(r => r.Driver)
                .Include(r => r.Engine)
                .Include(r => r.Cars)
                .Include(r => r.Conductors)
                .Include(r => r.Journeys)
                .AsSplitQuery()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Ride == null) return NotFound();

            TempRideConductors = await _context.Conductors
                .Include(c => c.ConductorEmployee)
                .Include(c => c.Ride)
                .Where(c => c.RideID == Ride.ID)
                .Select(c => c.ConductorEmployee)
                .ToListAsync();

            TempListCar = await _context.Cars
                .Include(c => c.Car)
                .Include(c => c.Ride)
                .Where(c => c.RideID == Ride.ID)
                .Select(c => c.Car)
                .ToListAsync();
            
            TempListConductorsWithoutRide =
                await _context.Employees
                    .Include(e => e.Permission)
                    .Where(e => e.Permission.Name == "conductor")
                    .Include(e => e.Conductors)
                    .Where(e => e.Conductors.Count == 0)
                    .ToListAsync();

            try
            {
                ListRideCars = new SelectList(TempListCar, "ID", "Name");
                ListAvailableCars = new SelectList(_context.Car.Where(c => c.Available), "ID", "Name");
                ListRideConductors = new SelectList(TempRideConductors, "ID", "Name");
                ListAvailableConductors = new SelectList(TempListConductorsWithoutRide, "ID", "Name");
                Engines = new SelectList(_context.Engines, "ID", "Name");
                Employees = new SelectList(_context.Employees, "ID", "Name");
            }
            catch (Exception e)
            {
                throw new Exception("ERROR", e);
            }
            return Page();
        }

        public IActionResult OnPostDeleteCar(int selectedCarId)
        {
            try
            {
                _carsController.RemoveCarFromRide(selectedCarId);
                _context.SaveChanges();
                _carController.MakeCarAvailable(selectedCarId);
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
        
        public IActionResult OnPostDeleteConductor(int selectedConductorId)
        {
            try
            {
                _conductorsController.RemoveConductorFromRide(selectedConductorId, Ride.ID);
                _context.SaveChanges();
                _employeeController.UpdateEmployee(selectedConductorId);
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
        
        public IActionResult OnPostAddConductor(int selectedConductorId)
        {
            Console.WriteLine("ON Add " + selectedConductorId);
            try
            {
                _conductorsController.AddConductorToRide(selectedConductorId, Ride.ID);
                _context.SaveChanges();
                _employeeController.UpdateEmployee(selectedConductorId);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR", e);
            }
            return RedirectToPage("Edit", Ride.ID);
        }

        public IActionResult OnPostAddCar(int selectedCarId)
        {
            Console.WriteLine("ON Add " + selectedCarId);
            try
            {
                _carsController.AddCarToRide(selectedCarId, Ride.ID);
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

            if (!ModelState.IsValid) return Page();

            try
            {
                Ride.DriverId = SelectedDriverId;
                Ride.Driver = await _context.Employees.FirstAsync(e => e.ID == SelectedDriverId);
                Ride.EngineId = SelectedEngineId;
                Ride.Engine = await _context.Engines.FirstAsync(e => e.ID == SelectedEngineId);
                Ride.Conductors = await _context.Conductors.Where(c => c.RideID == Ride.ID).ToListAsync();
                Ride.Cars = await _context.Cars.Where(c => c.RideID == Ride.ID).ToListAsync();
                _context.Attach(Ride).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RideExists(Ride.ID))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool RideExists(int id)
        {
            return _context.Rides.Any(e => e.ID == id);
        }
    }
}