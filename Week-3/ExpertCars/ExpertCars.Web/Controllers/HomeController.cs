using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExpertCars.Web.Models;

namespace ExpertCars.Web.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult About()
    {
      ViewData["Message"] = "Your application description page."; //->https://www.tektutorialshub.com/asp-net-core/asp-net-core-viewbag-viewdata/

      return View();
    }

    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] //->https://docs.microsoft.com/en-us/aspnet/core/performance/caching/response?view=aspnetcore-2.2
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
