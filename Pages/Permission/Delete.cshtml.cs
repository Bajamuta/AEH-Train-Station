using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Pages.Permission
{
    public class DeleteModel : PageModel
    {
        private readonly TrainStation.Data.TrainStationContext _context;

        public DeleteModel(TrainStation.Data.TrainStationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Permission Permission { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Permission = await _context.Permission.FirstOrDefaultAsync(m => m.ID == id);

            if (Permission == null)
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

            Permission = await _context.Permission.FindAsync(id);

            if (Permission != null)
            {
                _context.Permission.Remove(Permission);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
