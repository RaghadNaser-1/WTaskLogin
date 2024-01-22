namespace WTaskLogin.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Student>? Students { get; set; }

    }
}
