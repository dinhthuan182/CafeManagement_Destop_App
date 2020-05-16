using System.Configuration;

namespace CafeManagerDestopApp
{
    public static class Constant
    {
        const string PUSHER_APP_KEY = "625e6f2e093b6e564050";
        const string PUSHER_APP_CLUSTER = "ap1";
        const string PUSHER_APP_CHANNEL = "mobile";
        const string PUSHER_GET_TABLES_EVENT = "changeStateTable-event";

        static Constant()
        {
            if (string.IsNullOrWhiteSpace(AppKey))
            {
                AppKey = ConfigurationManager.AppSettings.Get(PUSHER_APP_KEY);
                AppCluster = ConfigurationManager.AppSettings.Get(PUSHER_APP_CLUSTER);
                AppChannel = ConfigurationManager.AppSettings.Get(PUSHER_APP_CHANNEL);
                tablesEvent = ConfigurationManager.AppSettings.Get(PUSHER_GET_TABLES_EVENT);
            }
        }

        public static string AppKey { get; }
        public static string AppCluster { get; }
        public static string AppChannel { get; }
        public static string tablesEvent { get; }

    }
}
