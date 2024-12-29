using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lumen.Modules.Sdk {
    public abstract class LumenModuleBase {
        private readonly LumenModuleRunsOnFlag runsOn;
        protected readonly ILogger<LumenModuleBase> logger;

        protected LumenModuleBase(LumenModuleRunsOnFlag runsOn, ILogger<LumenModuleBase> logger) {
            this.runsOn = runsOn;
            this.logger = logger;
        }

        // Generic methods
        public bool IsAPIModule() {
            return runsOn.HasFlag(LumenModuleRunsOnFlag.API);
        }
        public bool IsUIModule() {
            return runsOn.HasFlag(LumenModuleRunsOnFlag.UI);
        }
        public bool IsWorkerModule() {
            return runsOn.HasFlag(LumenModuleRunsOnFlag.Worker);
        }

        // Standard event loop methods
        public abstract Task InitAsync(LumenModuleRunsOnFlag currentEnv);
        public abstract Task ShutdownAsync();
        public abstract Task RunAsync(LumenModuleRunsOnFlag currentEnv);

        // Scheduled events
        public abstract bool ShouldRunNow(LumenModuleRunsOnFlag currentEnv);

        // Setup DI/DBContext/...
        public static void SetupServices(LumenModuleRunsOnFlag currentEnv, IServiceCollection serviceCollection, string? postgresConnectionString) {
            throw new NotImplementedException();
        }
        public abstract Type GetDatabaseContextType();
    }
}
