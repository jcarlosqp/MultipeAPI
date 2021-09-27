using System;
using System.Linq;
using XMLCompany.API.Models;

namespace XMLCompany.API.Services
{

    public class ShippingService : IShippingService
    {
        private static float Factor = 1.3f;

        public ResponseModel GetDeal(ParamsModel input)
        {
            try
            {
                int volume = input.GetVolume();
                FeeModel fee = Data.GetTestData.Where(d => d.ContactAddress == input.Source && d.WharehouseAddress == input.Destination)
                            .OrderBy(d => d.Volume)
                            .FirstOrDefault(d => d.Volume >= volume);

                return fee!=null ? new ResponseModel() { Quota = fee.Fee * Factor } : null;

            }
            catch (Exception)
            {
                //todo:log exception
                throw;
            }
        }
    }
}
