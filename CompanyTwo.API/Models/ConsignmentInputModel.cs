using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CompanyTwo.API.Models
{
    public class ConsignmentInputModel
    {
        [Required]
        public string Consignor { get; set; }
        [Required]
        public string Consignee { get; set; }
        [Required]
        public IEnumerable<int> Cartons { get; set; }

        public int GetVolume()
        {
            if (Cartons?.Count() > 0)
            {
                int volume = 1;
                Cartons.ToList().ForEach(d => volume *= d);
                return volume;
            }

            return 0;
        }
    }
}
