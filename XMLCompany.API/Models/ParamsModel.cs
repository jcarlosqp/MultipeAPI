using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace XMLCompany.API.Models
{
    public class ParamsModel
    {
        [Required]
        public string Source { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public IEnumerable<int> Packages { get; set; }

        public int GetVolume()
        {
            if (Packages?.Count() > 0)
            {
                int volume = 1;
                Packages.ToList().ForEach(d => volume *= d);
                return volume;
            }

            return 0;
        }
    }
}
