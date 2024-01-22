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

namespace WTaskLogin.Pages.Students
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly WTaskLogin.Data.WTaskContext _context;

        public IndexModel(WTaskLogin.Data.WTaskContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students
                .Include(s => s.Room)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
