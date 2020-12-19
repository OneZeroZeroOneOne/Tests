using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.Contexts;
using Tests.Dal.In;
using Tests.Dal.Models;
using Tests.Dal.Out;
using Tests.Security.Authorization;

namespace Tests.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly IMapper _mapperProfile;
        private readonly PositionService _positionService;
        public PositionController(MainContext context, PositionService positionService, IMapper mapperProfile)
        {
            _context = context;
            _mapperProfile = mapperProfile;
            _positionService = positionService;
        }

        [HttpPost]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<OutPositionViewModel> AddPosition(InPositionViewModel inPositionViewModel)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            Position newPosition = _mapperProfile.Map<Position>(inPositionViewModel);
            newPosition.UserId = authorizedUserModel.Id;
            await _positionService.AddPosition(newPosition);
            return _mapperProfile.Map<OutPositionViewModel>(newPosition);
        }

        [HttpGet]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<List<OutPositionViewModel>> AddUserPosition()
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            List<Position> userPositions = await _positionService.GetUserPositions(authorizedUserModel.Id);
            return _mapperProfile.Map<List<OutPositionViewModel>>(userPositions);
        }
    }
}
