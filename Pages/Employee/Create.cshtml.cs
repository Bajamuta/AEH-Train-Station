using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Pages.Employee
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
            Options = _context.Permission.Select(a => 
                new SelectListItem 
                {
                    Value = a.ID.ToString(),
                    Text =  a.Name
                }).ToList();
            return Page();
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }*/
            
            Options = _context.Permission.Select(a => 
                new SelectListItem 
                {
                    Value = a.ID.ToString(),
                    Text =  a.Name
                }).ToList();
            return Page();
        }
        

        public IActionResult OnSet()
        {
            Employee.PermissionID = Int32.Parse(PermissionID);
            var perm = _context.Permission.FirstOrDefault(v => v.ID == Employee.PermissionID);
            Employee.Type = perm;
            return Page();
        }
        
        public List<SelectListItem> Options { get; set; }
        // public int PermissionID { get; set; }

        [BindProperty]
        public Models.Employee Employee { get; set; }
        
        [BindProperty]
        public string PermissionID { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employee.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
