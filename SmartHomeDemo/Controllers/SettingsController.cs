using System.Web.Http;
using System.Web.Mvc;

namespace SmartHomeDemo.Controllers
{
    public class SettingsController : ApiController
    {
        // GET: Settings
        public ActionResult Index()
        {
            return new HttpNotFoundResult();
        }
    }
}