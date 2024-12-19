using CommandLine;
using Microsoft.Extensions.Logging;

namespace TagsCloudContainerCLI.CLI;

public class CliHandler
{
    private readonly ILogger<CliHandler> _logger;

    public CliHandler(ILogger<CliHandler> logger)
    {
        _logger = logger;
    }

    public void RunOptionsAndReturnExitCode(CliOptions opts)
    {
        if (opts.Demo) _logger.LogInformation("Demo mode is enabled.");

        if (!string.IsNullOrEmpty(opts.File)) _logger.LogInformation($"File path: {opts.File}");
    }

    public void HandleParseError(IEnumerable<Error> errs)
    {
        foreach (var error in errs) _logger.LogError(error.ToString());
    }
}