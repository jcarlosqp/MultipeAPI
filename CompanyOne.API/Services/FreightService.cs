using CompanyOne.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace CompanyOne.API.Services
{
    public class FreightService : IFreightService
    {
        
        public OutputModel GetDeal(InputModel input)
        {
            try
            {
                int volume = input.GetVolume();
                FeeModel fee = Data.GetTestData.Where(d => d.ContactAddress == input.ContactAddress && d.WharehouseAddress == input.WharehouseAddress)
                            .OrderBy(d => d.Volume)
                            .FirstOrDefault(d => d.Volume >= volume);

                return fee!=null ? new OutputModel() { Total = fee.Fee } : null;            

            }
            catch (System.Exception)
            {
                //todo:log exception
                throw;
            }
        }
    }
}
