using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTaskLogin.Data;
using WTaskLogin.Models;

namespace WTaskLogin.Pages.Students
{
    [Authorize]
    public class CreateModel : RoomNamePageModel
    {
        private readonly WTaskLogin.Data.WTaskContext _context;

        public CreateModel(WTaskLogin.Data.WTaskContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id");
            PopulateRoomsDropDownList(_context);

            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyStudent = new Student();

            if (await TryUpdateModelAsync<Student>(
                 emptyStudent,
                 "student",   // Prefix for form value.
                 s => s.Id, s => s.RoomId, s => s.FirstName, s => s.LastName))
            {
                _context.Students.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateRoomsDropDownList(_context, emptyStudent.RoomId);
            return Page();
        }
    }
}
