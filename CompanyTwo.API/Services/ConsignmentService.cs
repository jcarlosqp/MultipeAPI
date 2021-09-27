using CompanyTwo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTwo.API.Services
{
    public class ConsignmentService : IConsignmentService
    {
        private static float Factor = 1.2f;

        public ConsignmentOutputModel GetDeal(ConsignmentInputModel input)
        {
            try
            {
                int volume = input.GetVolume();
                FeeModel fee = Data.GetTestData.Where(d => d.ContactAddress == input.Consignor && d.WharehouseAddress == input.Consignee)
                            .OrderBy(d => d.Volume)
                            .FirstOrDefault(d => d.Volume >= volume);

                return fee != null ? new ConsignmentOutputModel() { Amount = fee.Fee * Factor } : null;            

            }
            catch (Exception)
            {
                //todo:log exception
                throw;
            }
        }
    }
}
