using Microsoft.AspNetCore.Mvc;
using Sample.Channel.Data;
using Sample.Channel.Data.Domain;
using Sample.Channel.Service;
using System.Threading.Channels;

namespace Cache.Redis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {

        private readonly ILogger<AuthorController> _logger;
        private ApplicationDbContext _applicationDbContext;

        public NotificationController(ILogger<AuthorController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        [Route("Call")]
        public IActionResult Call()
        {
            Task.Run(() =>
            {
                Task.Delay(100).Wait();

                Task.Delay(100).Wait();

                Task.Delay(100).Wait();
            });
            return Ok();
        }

        [HttpGet]
        [Route("CallNotification")]
        public bool CallNotification([FromServices] Notifications notify)
        {
            return notify.Send();
        }

        [HttpGet]
        [Route("CallNotificationByChannel")]
        public async Task<bool> CallNotificationByChannel([FromServices] Channel<string> notify)
        {
            await notify.Writer.WriteAsync("Hello");
            return true;
        }

        //[HttpGet(Name = "GetInfo")]
        //public string GetInfo()
        //{
        //    return "Hello Wolrd;";
        //}
    }
}