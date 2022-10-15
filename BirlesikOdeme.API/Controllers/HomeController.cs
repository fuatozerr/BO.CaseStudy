using AutoMapper;
using BirlesikOdeme.API.Dtos;
using BirlesikOdeme.Core.Entities.Dtos;
using BirlesikOdeme.Core.Entities.Mernis;
using BirlesikOdeme.Core.Entities.Payment;
using BirlesikOdeme.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BirlesikOdeme.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMernisService mernisService;
        private readonly IMapper mapper;
        private readonly IRestService restService;

        public HomeController(IMernisService mernisService, IMapper mapper, IRestService restService)
        {
            this.mernisService = mernisService;
            this.mapper = mapper;
            this.restService = restService;
        }

        [HttpPost]
        public async Task<IActionResult> CheckMernis([FromBody] CitizenRequestModel request)
        {
            var citizenModel = mapper.Map<Citizen>(request);
            var result = mernisService.CheckTCNumber(citizenModel);
            return Ok(result);

        }

        [HttpGet]
        public IActionResult Login()
        {
            var x = restService.Login();
            return Ok(x);

        }

        [HttpPost]
        public async Task<IActionResult> Sales([FromBody] SalesRequestModel request)
        {
            var salesModel = mapper.Map<SalesModel>(request);
            var result = restService.Sales(salesModel);
            return Ok(result);

        }
    }
}
