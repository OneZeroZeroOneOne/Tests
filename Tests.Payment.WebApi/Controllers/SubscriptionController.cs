using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.Models;
using Tests.Dal.Out;
using Tests.Security.Authorization;

namespace Tests.Payment.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;
        private readonly IMapper _mapperProfile;
        public SubscriptionController(SubscriptionService subscriptionService, IMapper mapperProfile)
        {
            _subscriptionService = subscriptionService;
            _mapperProfile = mapperProfile;
        }

        [HttpGet]
        [Authorize(Policy = "ClientAdmin")]
        [Route("Current")]
        public async Task<OutSubscriptionViewModel> GetCurrentSubscription()
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            Subscription subscription = await _subscriptionService.GetCurrent(authorizedUserModel.Id);
            return _mapperProfile.Map<OutSubscriptionViewModel>(subscription);
        }

        [HttpGet]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<List<OutSubscriptionViewModel>> GetSubscriptions()
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            List<Subscription> subscription = await _subscriptionService.GetAllSubscriptions(authorizedUserModel.Id);
            return _mapperProfile.Map<List<OutSubscriptionViewModel>>(subscription);
        }

        [HttpGet]
        [Authorize(Policy = "ClientAdmin")]
        [Route("Type")]
        public async Task<List<OutSubscriptionTypeViewModel>> GetSubscriptionTypes()
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            List<SubscriptionType> subscriptionTypes = await _subscriptionService.GetSubscriptionTypes();
            return _mapperProfile.Map<List<OutSubscriptionTypeViewModel>>(subscriptionTypes);
        }
    }
}