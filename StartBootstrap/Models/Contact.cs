namespace StartBootstrap.Models
{
    public class Contact:Base
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public bool Isread { get; set; }

     }
}
