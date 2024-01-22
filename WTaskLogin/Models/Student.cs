using System.ComponentModel.DataAnnotations;

namespace WTaskLogin.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // Foreign key property
        [Display(Name = "Grade")]
        public int RoomId { get; set; }

        // Navigation property
        [Display(Name = "Grade")]
        public Room? Room { get; set; }

    }
}
