using XMLCompany.API.Models;

namespace XMLCompany.API.Services
{
    public interface IShippingService
    {
        ResponseModel GetDeal(ParamsModel input);
    }
}