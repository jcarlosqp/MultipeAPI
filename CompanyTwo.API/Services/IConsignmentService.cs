using CompanyTwo.API.Models;

namespace CompanyTwo.API.Services
{
    public interface IConsignmentService
    {
        ConsignmentOutputModel GetDeal(ConsignmentInputModel input);
    }
}