using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly TrainStation.Data.ApplicationDbContext _context;

        public IndexModel(TrainStation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employee.ToListAsync();
        }
    }
}
