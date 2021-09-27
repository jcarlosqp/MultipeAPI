using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BestDeal.Core.Models
{
    public class SearchParams
    {
        [Required]
        public string SourceAddress { get; set; }
        [Required]
        public string DestinationAddress { get; set; }
        [Required]
        public IEnumerable<int> CartonDimensions { get; set; }
    }
}
