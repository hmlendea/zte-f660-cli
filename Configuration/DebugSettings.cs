namespace ZTEF660CLI.Configuration
{
    public sealed class DebugSettings
    {
        public string LogFilePath { get; set; }

        public string CrashScreenshotFilePath { get; set; }

        public bool IsDebugMode { get; set; }

        public bool IsLoggingEnabled => !string.IsNullOrWhiteSpace(LogFilePath);

        public bool IsCrashScreenshotEnabled => !string.IsNullOrWhiteSpace(CrashScreenshotFilePath);
    }
}
