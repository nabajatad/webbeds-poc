namespace WebBeds.UI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using WebBeds.Service;
    using WebBeds.UI.Models;
    using WebBeds.Utility;

    public class HomeController : Controller
    {
        private ILogger logger;
        private IHotelService service;
        private AppSettings appSettings;

        public HomeController(IHotelService svc, ILogger log,  IConfiguration config)
        {
            this.appSettings = new AppSettings
            {
                ApiUrl = config.GetSection("AppSettings")["WebBedsAPI_URL"],
                AuthCode = config.GetSection("AppSettings")["WebBedsAPI_AuthCode"],
                MethodName = config.GetSection("AppSettings")["WebBedsAPI_FindBargain_MethodName"]
            };
            this.service = svc;
            this.logger = log;
        }
        /// <summary>
        /// Action method to return a view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Search hotels by DestinationId and Nights 
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Get all the searched hotels</returns>
        [HttpPost]
        public async Task<IActionResult> Index(SearchRequestModel request)
        {
            ViewResult returnView;
            try
            {
                ViewData["ResultSet"] = await service.GetHotels(this.appSettings.MethodName, request.DestinationId, request.Nights, this.appSettings.AuthCode);

                returnView = View();
            }
            catch (Exception ex)
            {
                logger.WriteErrorLog(ex.Message);
                returnView = View("../Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ExceptionMessage = ex.Message });
            }
            return returnView;
        }
    }
}
