using Microsoft.AspNetCore.Mvc.Versioning;
using System.Reflection;

namespace Duplicati.WebserverWebApi;

public class MyWebServer
{
    /// <summary>
    /// Name of the webapplication for the builder
    /// </summary>
    private const string ApplicationName = "Duplicati.WebserverWebApi";
    
    /// <summary>
    /// Filename of the configuration file for the reverse proxy
    /// </summary>
    private const string ConfigFilename = "ReverseProxyConfig.json";
    
    /// <summary>
    /// Title of the configuration section that holds the proxy configuration options 
    /// </summary>
    private const string ConfigSectionName = "ReverseProxy";
        
    /// <summary>
    /// Path of the configuration file for the reverse proxy from 
    /// (config file should be in the same directory as the executing assembly)
    /// </summary>
    private readonly string ConfigPath;

    public MyWebServer()
    {
        var assemblyPath = (new System.Uri(Assembly.GetExecutingAssembly().Location)).AbsolutePath;
        var assemblyDir = Path.GetDirectoryName(assemblyPath);
        ConfigPath = Path.Join(assemblyDir, ConfigFilename);

    }
    
    
    // Starts the webserver on the given port and returns an action that can be used to stop it
    public Action Start(int port)
    {
        var builder = WebApplication.CreateBuilder(
            new WebApplicationOptions{
                ApplicationName=ApplicationName
            }
        );
        builder.Host.ConfigureAppConfiguration((hostingContext,config) => 
        {
            config.AddJsonFile(
                ConfigPath,
                optional: false,
                reloadOnChange: false);
        });

        builder.WebHost.UseUrls($"http://localhost:{port}");

        builder.Services.AddControllers();

        var proxyBuilder = builder.Services.AddReverseProxy();
        proxyBuilder.LoadFromConfig(builder.Configuration.GetSection(ConfigSectionName));
        
        var app = builder.Build();
        
        app.UseFileServer();

        app.MapReverseProxy();
        app.MapControllers();
        
        app.Run();

        return () =>  { app.StopAsync(); };
    }
}