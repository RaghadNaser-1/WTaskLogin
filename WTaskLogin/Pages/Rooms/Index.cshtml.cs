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
    public class IndexModel : PageModel
    {
        private readonly WTaskLogin.Data.WTaskContext _context;

        public IndexModel(WTaskLogin.Data.WTaskContext context)
        {
            _context = context;
        }

        public IList<Room> Room { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Room = await _context.Rooms.ToListAsync();
        }
    }
}
