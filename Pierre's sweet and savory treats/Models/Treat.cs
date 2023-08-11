using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PierreTreats.Models
{
    public class Treat
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // ... Other properties

        public ICollection<TreatFlavor> TreatFlavors { get; set; }
    }
}
