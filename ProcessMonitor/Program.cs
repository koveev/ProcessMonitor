using Serilog;

using System;
using System.Threading;

namespace ProcessMonitor
{
	public class Program
	{
		static void	Main(string[] args)
		{
			Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.Console()
				.WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
				.CreateLogger();

			try
			{
				var monitor = new Monitor(new ParametersMonitor(args[0], double.Parse(args[1]), double.Parse(args[2])));

				Log.Information($"Monitoring of the '{args[0]}' process has started...");
				monitor.MonitoringProcess();

				Log.Information("Process exited");
			}
			catch(Exception)
			{
				Log.Error("Parameters are incorrect or the process is not running");
			}
		}
	}
}
