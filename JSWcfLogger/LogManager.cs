using System;
using System.Linq;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace JSWcfLogger
{
    public class LogManager
    {
        private string LogsFolder = @"C:\ProgramData\DaletLogs";
        
        private static LogManager _instance = new LogManager();

        public static LogManager Instance
        {
            get { return _instance; }
        }

        public void HandleLog(string appName,LogLevel logLevel, string logMessage)
        {
            Logger logger = null;
                
            if (!NLog.LogManager.Configuration.ConfiguredNamedTargets.Any(t => t.Name.Equals("NameToValidate")))
            { 
                var target = new FileTarget();
                target.Name = appName;
                target.FileName = LogsFolder +"/"+appName+ "/${shortdate}.log";
                target.Layout = "${date:format=HH\\:MM\\:ss} ${logger} ${message}";
                var config = new LoggingConfiguration();
                config.AddTarget(appName, target);
                var rule = new LoggingRule("*", LogLevel.Info, target);
                config.LoggingRules.Add(rule);
                NLog.LogManager.Configuration = config;
                logger = NLog.LogManager.GetLogger(appName);
                logger.Info("Logger is initialized");

            }
            else
            {
                logger = NLog.LogManager.GetLogger(appName);
            }
            logger.Log(logLevel, logMessage); 
        }

    }
}