namespace Pierre_s_sweet_and_savory_treats.Models
{
    public class Treat
    {
        internal readonly int TreatId;

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TreatFlavor> TreatFlavors { get; set; }
    }
}
