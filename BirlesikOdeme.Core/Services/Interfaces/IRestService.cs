using BirlesikOdeme.Core.Entities;

namespace BirlesikOdeme.Core.Services.Interfaces
{
    public interface IRestService
    {
        Task<SecurityResponseModel> Login();
        Task<SalesModel> Sales(SalesModel salesModel);
    }
}