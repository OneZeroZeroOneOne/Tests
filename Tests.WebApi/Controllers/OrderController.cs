using Microsoft.AspNetCore.Mvc;
using Tests.Bll.Services;
using Tests.Dal.Contexts;
using Tests.Dal.In;

namespace Tests.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly AvatarService _avatarService;
        public OrderController(MainContext context)
        {
            _context = context;
        }

        public async string Pay(InPaySubscriptionsViewModel inPaySubscriptionsViewModel)
        {
            
        }
    }
}
