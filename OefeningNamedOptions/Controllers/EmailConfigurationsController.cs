using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OefeningNamedOptions.Models;

namespace OefeningNamedOptions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailConfigurationsController : ControllerBase
    {
        private readonly IOptionsSnapshot<EmailOptions> _options;

        public EmailConfigurationsController(IOptionsSnapshot<EmailOptions> options)
        {
            _options = options;
        }

        [HttpGet]
        [Route("email-configurations")]
        public IActionResult GetEmailConfigurations()
        {
            var gmail = _options.Get(EmailOptions.GmailSectionName);
            var outlook = _options.Get(EmailOptions.OutlookSectionName);
            return Ok(new { GmailConfiguration = gmail, OutlookConfiguration = outlook });
        }
    }
}
