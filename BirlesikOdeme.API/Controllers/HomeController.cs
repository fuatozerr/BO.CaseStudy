using AutoMapper;
using BirlesikOdeme.API.Dtos;
using BirlesikOdeme.Core.Entities;
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

        public HomeController(IMernisService mernisService, IMapper mapper)
        {
            this.mernisService = mernisService;
            this.mapper = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> CheckMernis([FromBody] VatandasRequestModel request)
        {
            var vatandas = mapper.Map<Vatandas>(request);
            var result = mernisService.CheckTCNumber(vatandas);
            return Ok(result);

        }
    }
}
