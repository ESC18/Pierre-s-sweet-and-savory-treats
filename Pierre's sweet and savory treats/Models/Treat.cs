using PierreTreats.Models;
using System.Collections.Generic;

namespace Pierre_s_sweet_and_savory_treats.Models
{
    public class Treat
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property for many-to-many relationship
        public ICollection<TreatFlavor> TreatFlavors { get; set; }
    }
}
