using CompanyOne.API.Models;

namespace CompanyOne.API.Services
{
    public interface IFreightService
    {
        OutputModel GetDeal(InputModel input);
    }
}