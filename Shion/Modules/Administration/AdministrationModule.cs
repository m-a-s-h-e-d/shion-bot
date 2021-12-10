﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shion.Core.Preconditions;
using Shion.Modules.Utility;

namespace Shion.Modules.Administration
{
    public class AdministrationModule : ModuleBase<ShardedCommandContext>
    {
        private readonly ILogger<AdministrationModule> _logger;
        //You can inject the host. This is useful if you want to shutdown the host via a command, but be careful with it.
        private readonly IHost _host;

        public AdministrationModule(IHost host, ILogger<AdministrationModule> logger)
        {
            _host = host;
            _logger = logger;
        }

        [Command("shutdown")]
        [RequireBotOwner]
        public async Task Stop()
        {
            _ = _host.StopAsync();
        }

        [Command("log")]
        [RequireBotOwner]
        public Task TestLogs()
        {
            _logger.LogTrace("This is a trace log");
            _logger.LogDebug("This is a debug log");
            _logger.LogInformation("This is an information log");
            _logger.LogWarning("This is a warning log");
            _logger.LogError(new InvalidOperationException("Invalid Operation"), "This is a error log with exception");
            _logger.LogCritical(new InvalidOperationException("Invalid Operation"), "This is a critical load with exception");

            _logger.Log(GetLogLevel(LogSeverity.Error), "Error logged from a Discord LogSeverity.Error");
            _logger.Log(GetLogLevel(LogSeverity.Info), "Information logged from Discord LogSeverity.Info");

            return Task.CompletedTask;
        }

        private static LogLevel GetLogLevel(LogSeverity severity)
            => (LogLevel)Math.Abs((int)severity - 5);
    }
}
