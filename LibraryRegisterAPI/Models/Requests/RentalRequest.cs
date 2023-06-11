namespace LibraryRegisterAPI.Models.Requests
{
    public class RentalRequest
    {
        public int Id { get; set; }

        public DateTime RentalStartDate { get; set; }

        public DateTime RentalEndDate { get; set; }

        public bool RentalStatus { get; set; }

        public int MemberId { get; set; }

        public int BookId { get; set; }
    }
}
