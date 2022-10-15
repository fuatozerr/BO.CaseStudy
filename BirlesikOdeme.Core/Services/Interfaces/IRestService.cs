using BirlesikOdeme.Core.Entities.Payment;
using BirlesikOdeme.Core.Entities.Security;

namespace BirlesikOdeme.Core.Services.Interfaces
{
    public interface IRestService
    {
        Task<SecurityResponseModel> Login();
        Task<PaymentResponseModel> Sales(SalesModel salesModel);
    }
}