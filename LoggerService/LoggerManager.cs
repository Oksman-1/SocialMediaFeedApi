using Contracts;
using Microsoft.AspNetCore.Builder;
using Serilog;

namespace LoggerService;

public class LoggerManager : ILoggerManager
{
	private static readonly WebApplicationBuilder builder = WebApplication.CreateBuilder();

	//Configure Serilog
	private static Serilog.ILogger logger = new LoggerConfiguration()
		.ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
		.WriteTo.Console()
        .CreateLogger();

    public LoggerManager()
    {
            
    }
    public void LogDebug(string message) => logger.Debug(message);
	public void LogError(string message) => logger.Error(message);
	public void LogInfo(string message) => logger.Information(message);	
	public void LogWarn(string message) => logger.Warning(message);	
	
}
