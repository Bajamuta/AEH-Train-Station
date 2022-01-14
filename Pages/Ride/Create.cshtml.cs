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
    public class CreateModel : PageModel
    {
        private readonly TrainStationContext _context;
        private readonly CarController _carController;
        private readonly CarsController _carsController;
        private readonly ConductorsController _conductorsController;
        private readonly EmployeeController _employeeController;

        public CreateModel(TrainStationContext context)
        {
            _context = context;
            _carsController = new CarsController(context);
            _carController = new CarController(context);
            _employeeController = new EmployeeController(context);
            _conductorsController = new ConductorsController(context);
            Ride = new Models.Ride();
            TempRideConductors = new List<Models.Employee>();
            TempListRideCar = new List<Models.Car>();

            TempListConductorsWithoutRide =
                _context.Employees
                    .Include(e => e.Permission)
                    .Where(e => e.Permission.Name == "conductor")
                    .Include(e => e.Conductors)
                    .Where(e => e.Conductors.Count == 0)
                    .ToList();

            TempListAvailableCars = _context.Car.Where(c => c.Available).ToList();
        }
        
        [BindProperty] public Models.Ride Ride { get; set; }

        [BindProperty] public int SelectedEngineId { get; set; }

        [BindProperty] public int SelectedCarId { get; set; }

        [BindProperty] public int SelectedDriverId { get; set; }

        [BindProperty] public int SelectedConductorId { get; set; }
        
        public SelectList Engines { get; set; }
        public SelectList Employees { get; set; }
        public SelectList ListAvailableCars { get; set; }
        public SelectList ListAvailableConductors { get; set; }
        public SelectList ListRideCars { get; set; }
        public SelectList ListRideConductors { get; set; }
        public List<Models.Employee> TempListConductorsWithoutRide { get; set; }
        public List<Models.Employee> TempRideConductors { get; set; }
        public List<Models.Car> TempListRideCar { get; set; }
        public List<Models.Car> TempListAvailableCars { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            
            
            Engines = new SelectList(_context.Engines, "ID", "Name");
            Employees = new SelectList(_context.Employees, "ID", "Name");
            ListAvailableConductors = new SelectList(TempListConductorsWithoutRide, "ID", "Name");
            ListAvailableCars = new SelectList(TempListAvailableCars, "ID", "Name");
            ListRideCars = new SelectList(TempListRideCar, "ID", "Name");
            ListRideConductors = new SelectList(TempRideConductors, "ID", "Name");
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
            return RedirectToPage("Create", Ride.ID);
        }
        
        public IActionResult OnPostDeleteConductor(int selectedConductorIdRide)
        {
            Models.Employee em = TempRideConductors.Find(i => i.ID == selectedConductorIdRide);
            TempRideConductors.Remove(em);
            try
            {
                _conductorsController.RemoveConductorFromRide(selectedConductorIdRide, Ride.ID);
                _context.SaveChanges();
                _employeeController.UpdateEmployee(selectedConductorIdRide);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR", e);
            }

            Console.WriteLine("ON Delete ");
            // SelectedCarId = 0;
            return RedirectToPage("Create", Ride.ID);
        }
        
        public IActionResult OnPostAddConductor(int selectedConductorIdAvailable)
        {
            Models.Employee em = _context.Employees
                .First(i => i.ID == selectedConductorIdAvailable);
            try
            {
                TempRideConductors.Add(em);
                TempListConductorsWithoutRide.Remove(em);
                /*_conductorsController.AddConductorToRide(selectedConductorId, Ride.ID);
                _context.SaveChanges();
                _employeeController.UpdateEmployee(selectedConductorId);
                _context.SaveChanges();*/
            }
            catch (Exception e)
            {
                throw new Exception("ERROR", e);
            }
            return RedirectToPage("Create");
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
            return RedirectToPage("Create", Ride.ID);
        }

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
