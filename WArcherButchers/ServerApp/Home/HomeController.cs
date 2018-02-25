using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WArcherButchers.Infrastructure.Settings;

namespace WArcherButchers.ServerApp.Home
{
    public class HomeController : Controller
    {
        private readonly IOptions<Auth0Settings> _auth0SettingsOptions;
        private readonly IOptions<ServerSettings> _serverSettingsOptions;

        public HomeController(
            IOptions<Auth0Settings> auth0SettingsOptions,
            IOptions<ServerSettings> serverSettingsOptions)
        {
            _auth0SettingsOptions = auth0SettingsOptions;
            _serverSettingsOptions = serverSettingsOptions;
        }

        public IActionResult Index()
        {
            ViewData["Server.Url"] = _serverSettingsOptions.Value.Url;
            ViewData["Client.Url"] = _serverSettingsOptions.Value.Url;
            ViewData["Auth0.ApiUrl"] = _serverSettingsOptions.Value.Url;
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