using HelloCoreWorld.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelloCoreWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //step1
        IDataProtector _dataProtector;


        //step2
        //public HomeController(ILogger<HomeController> logger)
        public HomeController(ILogger<HomeController> logger, IDataProtectionProvider provider)
        {
            _logger = logger;

            //step3
            _dataProtector = provider.CreateProtector(GetType().FullName);
        }

        public IActionResult Index()
        {
            TestModel testModel = new TestModel();
            var protectedData = _dataProtector.Protect("Hello Chubbly bubbly");
            //testModel.ProtectedData = "Protected Data: " + protectedData;

            var unProtectedData = _dataProtector.Unprotect(protectedData);
            //testModel.UnProtectedData = "UnProtected Data: " + unProtectedData;

            return View(testModel);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}



        public IActionResult Interactive()
        {
            return View();
        }

        public IActionResult Architecture()
        {
            return View();
        }

        public IActionResult Games()
        {
            return View();
        }

        public IActionResult Courses()
        {
            return View();
        }

        public IActionResult AI()
        {
            return View();
        }

        public IActionResult Animation()
        {
            return View();
        }

        public IActionResult Food()
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
