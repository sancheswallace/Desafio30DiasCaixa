using System.Diagnostics;

namespace MinhaApi.Telemetry;

public static class TelemetrySources
{
    public const string ActivitySourceName = "MinhaApi";
    public static readonly ActivitySource ActivitySource = new(ActivitySourceName);
}
