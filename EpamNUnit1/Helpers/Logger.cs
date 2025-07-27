using log4net;
using log4net.Config;
using System.Reflection;

namespace EpamNUnit1.Helpers;

public class Logger
{
    private readonly static Logger _logger = new Logger();
    private ILog _log = LogManager.GetLogger(typeof(Logger));

    private Logger()
    {
        var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
    }

    public static Logger Instance => _logger;

    public static void LogInfo<T>(string message)
    {
        Instance._log.Info($"[{typeof(T).Name}] {message}");
    }

    public static void LogError<T>(string message, Exception? ex = null)
    {
        if (ex == null)
        {
            Instance._log.Error($"[{typeof(T).Name}] {message}");

        }
        else
        {
            Instance._log.Error($"[{typeof(T).Name}] {message}", ex);

        }
    }

    public static void LogWarn<T>(string message)
    {
        Instance._log.Warn($"[{typeof(T).Name}] {message}");
    }

    public static void LogDebug<T>(string message)
    {
        Instance._log.Debug($"[{typeof(T).Name}] {message}");
    }
}
