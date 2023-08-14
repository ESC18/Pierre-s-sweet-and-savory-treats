namespace Pierre_s_sweet_and_savory_treats.Models
{
    public class Flavor
    {
        public int FlavorId { get; set; }
        public string Name { get; set; }
        public ICollection<TreatFlavor> TreatFlavors { get; set; }
    }
}
