using Microsoft.AspNetCore.Mvc;

namespace Duplicati.WebserverWebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AcknowledgementsController : ControllerBase
{
    private readonly ILogger<AcknowledgementsController> _logger;

    public AcknowledgementsController(ILogger<AcknowledgementsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public string Get()
    {
        return "{\"Status\": \"OK\", \"Acknowledgements\": \"This sentence is served from the new asp.net core 6 webapi webserver while the remaining page comes from the existing implementation\"}";
    }
}