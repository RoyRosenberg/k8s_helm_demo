using K8S.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Diagnostics;

namespace K8S.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptionsSnapshot<RedisSetting> redisOptions;

        public HomeController(ILogger<HomeController> logger, IOptionsSnapshot<RedisSetting> redisOptions)
        {
            _logger = logger;
            this.redisOptions = redisOptions;
        }

        public IActionResult Index()
        {
            try
            {
                string server = $"{redisOptions.Value.Server}:{redisOptions.Value.Port}";
                ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(server);
                IDatabase db = redis.GetDatabase();
                ViewData["Data"] = db.StringGet("foo");
            }
            catch (Exception ex)
            {
                ViewData["Data"] = ex.Message;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
