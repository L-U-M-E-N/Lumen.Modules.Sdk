using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lumen.Modules.Sdk {
    public abstract class LumenModuleBase(IEnumerable<ConfigEntry> configEntries, ILogger<LumenModuleBase> logger, IServiceProvider provider) {
        protected readonly IEnumerable<ConfigEntry> configEntries = configEntries;
        protected readonly ILogger<LumenModuleBase> logger = logger;
        protected readonly IServiceProvider provider = provider;

        // Standard event loop methods
        public abstract Task InitAsync(LumenModuleRunsOnFlag currentEnv);
        public abstract Task ShutdownAsync();
        public abstract Task RunAsync(LumenModuleRunsOnFlag currentEnv, DateTime date);

        // Scheduled events
        public abstract bool ShouldRunNow(LumenModuleRunsOnFlag currentEnv, DateTime date);

        // Setup DI/DBContext/...
        public static void SetupServices(LumenModuleRunsOnFlag currentEnv, IServiceCollection serviceCollection, string? postgresConnectionString) {
            throw new NotImplementedException();
        }
        public abstract Type? GetDatabaseContextType();
    }
}
