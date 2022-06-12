namespace StartBootstrap.Models
{
    public class Portfolio:Base
    {
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
       
    }
}
