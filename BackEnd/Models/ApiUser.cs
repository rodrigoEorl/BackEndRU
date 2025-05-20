namespace BackEnd.Models
{
    public class ApiUser
    {
        public string Gender { get; set; }
        public Name Name { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        public Dob Dob { get; set; }
        public Picture Picture { get; set; }
    }
}
