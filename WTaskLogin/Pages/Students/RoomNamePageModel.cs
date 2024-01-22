using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WTaskLogin.Data;
using WTaskLogin.Models;

namespace WTaskLogin.Pages.Students
{
    public class RoomNamePageModel : PageModel
    {
        public SelectList RoomNameSL { get; set; }

        public void PopulateRoomsDropDownList(WTaskContext _context,
            object selectedRoom = null)
        {
            var roomsQuery = from d in _context.Rooms
                             orderby d.Name // Sort by name.
                             select d;

            RoomNameSL = new SelectList(roomsQuery,
                nameof(Room.Id),
                nameof(Room.Name),
                selectedRoom);
        }

    }
}
