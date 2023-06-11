namespace LibraryRegisterAPI.Models.Requests
{
    public class MemberRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
