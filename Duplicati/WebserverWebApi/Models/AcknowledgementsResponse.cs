using System.Text.Json.Serialization;

namespace Duplicati.WebserverWebApi.Models;


public class AcknowledgementsResponse 
{   
    [JsonPropertyName("Status")]
    public string Status {get; init;}

    [JsonPropertyName("Acknowledgements")]
    public string Acknowledgements {get; init;}
}