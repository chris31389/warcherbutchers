using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WArcherButchers.Infrastructure.Settings;

namespace WArcherButchers.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<ApprovalsSettings> _approvalSettingsOptions;
        private readonly IOptions<Auth0Settings> _auth0SettingsOptions;
        private readonly IOptions<WebServerSettings> _serverSettingsOptions;

        public HomeController(
            IOptions<ApprovalsSettings> approvalSettingsOptions,
            IOptions<Auth0Settings> auth0SettingsOptions,
            IOptions<WebServerSettings> serverSettingsOptions)
        {
            _approvalSettingsOptions = approvalSettingsOptions;
            _auth0SettingsOptions = auth0SettingsOptions;
            _serverSettingsOptions = serverSettingsOptions;
        }

        public IActionResult Index()
        {
            ViewData["Approvals.Url"] = _approvalSettingsOptions.Value.Url;
            ViewData["Auth0.ApiUrl"] = _approvalSettingsOptions.Value.Url;
            ViewData["Auth0.CallbackUrl"] = $"{_serverSettingsOptions.Value.Url.Trim('/')}/callback";
            ViewData["Auth0.Domain"] = _auth0SettingsOptions.Value.Domain;
            ViewData["Auth0.ClientId"] = _auth0SettingsOptions.Value.ClientId;
            ViewData["Auth0.SilentUrl"] = $"{_serverSettingsOptions.Value.Url.Trim('/')}/silent";
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}