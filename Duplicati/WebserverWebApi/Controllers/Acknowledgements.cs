using Microsoft.AspNetCore.Mvc;
using Duplicati.WebserverWebApi.Models;
using System.Reflection;

namespace Duplicati.WebserverWebApi.Controllers;

/// <summary>
/// Acknowledgements Controller
/// Provides the REST endpoint /acknowledgements which is called from the ui
/// to retrieve the acknowledgements text that is to be displayed on the About section 
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class AcknowledgementsController : ControllerBase
{
    /// <summary>
    /// Filename of the text file that contains the acknowledgements
    /// </summary>
    private const string AcknowledgementsFilename = "acknowledgements.txt";

    /// <summary>
    /// Logger
    /// </summary>    
    private readonly ILogger<AcknowledgementsController> _logger;

    /// <summary>
    /// C'tor to create an instance of the AcknowledgementsController
    /// </summary>
    public AcknowledgementsController(ILogger<AcknowledgementsController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// GET api/v1/acknowledgements
    /// Reads acknowledgements from file and returns them
    /// </summary>    
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<AcknowledgementsResponse> Get()
    {
        // var acknowledgements = string.Empty;

        // var filePath = Path.Join(
        //     Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
        //     AcknowledgementsFilename);

        // try 
        // {
        //     acknowledgements = System.IO.File.ReadAllText(filePath);
        // } 
        // catch (Exception e)
        // {
        //     _logger.LogError(
        //         e,
        //         "Failed reading {0} from {1} ",
        //         AcknowledgementsFilename,
        //         filePath);
            
        //     return StatusCode(StatusCodes.Status500InternalServerError);
        // }

        // var response = new AcknowledgementsResponse {
        //     Status = "OK",
        //     Acknowledgements = acknowledgements
        // };

        // return Ok(response);

        return new AcknowledgementsResponse {
            Status = "OK",
            Acknowledgements =
                "This sentence is served from the new asp.net core 6 webapi webserver while the remaining page comes from the existing implementation"
        };
    }
}