using System.Collections.Generic;

namespace Pierre_s_sweet_and_savory_treats.ViewModels
{
    public class TreatViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<FlavorViewModel> AvailableFlavors { get; set; }
    }
}
