using Microsoft.AspNetCore.Mvc;

namespace K8S.WebApp.Controllers
{
    public class NumberController : Controller
    {
        public IActionResult Index(int id = 1)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < id; i++)
            {
                res.Add(Random.Shared.Next(0, 100));
            }
            return Ok(res);
        }
    }
}
