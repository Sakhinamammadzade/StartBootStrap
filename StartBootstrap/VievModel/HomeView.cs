using StartBootstrap.Models;

namespace StartBootstrap.VievModel
{
    public class HomeView
    {
        public Banner Banner { get; set; }
        public List <Services >Services { get; set; }
        public List<Portfolio> Portfolios { get; set; }
        public Contact Contact { get; set; }
    }
}
