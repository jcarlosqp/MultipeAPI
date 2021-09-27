using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CompanyOne.API.Models
{
    public class InputModel
    {
        [Required]
        public string ContactAddress { get; set; }
        [Required]
        public string WharehouseAddress { get; set; }
        [Required]
        public IEnumerable<int> Dimensions { get; set; }

        public int GetVolume()
        {            
            if (Dimensions?.Count()>0)
            {
                int volume = 1;
                Dimensions.ToList().ForEach(d => volume *= d);
                return volume;
            }

            return 0;
        }
    }
}
