using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTaskLogin.Data;
using WTaskLogin.Models;

namespace WTaskLogin.Pages.Rooms
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly WTaskContext _context;

        public DetailsModel(WTaskContext context)
        {
            _context = context;
        }

        public Room Room { get; set; } = default!;
        public List<Student> Students { get; set; } = new List<Student>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = await _context.Rooms
                .Include(r => r.Students) // Include students associated with the room
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Room == null)
            {
                return NotFound();
            }

            Students = Room.Students?.ToList() ?? new List<Student>();

            return Page();
        }
    }
}
