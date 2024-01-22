using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class EditModel : RoomNamePageModel
    {
        private readonly WTaskLogin.Data.WTaskContext _context;

        public EditModel(WTaskLogin.Data.WTaskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                                .Include(c => c.Room).FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
            {
                return NotFound();
            }
            Student = student;
            // ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id");
            PopulateRoomsDropDownList(_context, Student.RoomId);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentToUpdate = await _context.Students.FindAsync(id);

            if (studentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Student>(
                 studentToUpdate,
                 "student",   // Prefix for form value.
                   c => c.FirstName, c => c.LastName, c => c.RoomId))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateRoomsDropDownList(_context, studentToUpdate.RoomId);

            return Page();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
