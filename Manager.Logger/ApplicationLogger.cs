using Manager.Application.Logger;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Text;

namespace Manager.Logger
{
    public class ApplicationLogger : IApplicationLogger
    {
		public IConfiguration Configuration { get; }

		private Serilog.Core.Logger Log { get; }

		public ApplicationLogger(IConfiguration configuration)
		{
			Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
			Log = CreateLogger();
		}

		private Serilog.Core.Logger CreateLogger()
		{
			try
			{
				StringBuilder connectionString = new StringBuilder(Configuration.GetConnectionString("AirlineDB"));

				var options = new ColumnOptions();

				Serilog.LoggerConfiguration configuration = new Serilog.LoggerConfiguration()
						.MinimumLevel.Debug()
						.WriteTo.MSSqlServer(
							connectionString: connectionString.ToString(),
							tableName: "Logs",
							schemaName: "dbo",
							autoCreateSqlTable: true,
							columnOptions: options
						);
				
				return configuration.CreateLogger();
			}
			catch(Exception)
			{
				throw;
			}
		}

        public void Information(string message)
        {
            Log.Information(message);
        }

        public void Debug(string message)
		{
			Log.Debug(message);
		}

		public void Warn(string message)
		{
			Log.Warning(message);
		}

		public void Error(Exception ex, string message)
		{
			Log.Error(ex, message);
		}

		public void Fatal(Exception ex, string message)
		{
			Log.Fatal(ex, message);
		}
    }
}