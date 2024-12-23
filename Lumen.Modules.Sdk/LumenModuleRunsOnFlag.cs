namespace Lumen.Modules.Sdk {
    [Flags]
    public enum LumenModuleRunsOnFlag {
        None = 0,
        UI = 1,
        Worker = 2,
        API = 3
    }
}
