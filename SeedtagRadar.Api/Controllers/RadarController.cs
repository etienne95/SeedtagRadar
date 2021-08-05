using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SeedtagRadar.Application.DTOs;
using SeedtagRadar.Domain.Entities;
using SeedtagRadar.Domain.Interfaces;

namespace SeedtagRadar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RadarController : ControllerBase
    {
        private readonly IScanService _scanService;
        private readonly IMapper _mapper;

        public RadarController(IScanService scanService, IMapper mapper)
        {
            _scanService = scanService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PointDto), (int)HttpStatusCode.OK)]
        public PointDto Post(AttackInstruction request)
        {
            return _mapper.Map<PointDto>(_scanService.GetTargetPoint(request));
        }
    }
}
