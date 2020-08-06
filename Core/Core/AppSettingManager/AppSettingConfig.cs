using Microsoft.Extensions.Configuration;

namespace Core.Core
{
    public class AppSettingConfig
    {
        private static IConfiguration _config;

        private AppSettingConfig() { }
        readonly static object obj = new object();
        static AppSettingConfig _AppSettingConfig;
        public static AppSettingConfig GetAppSetting()
        {
            lock (obj)
            {
                if (_AppSettingConfig == null)
                {
                    _AppSettingConfig = new AppSettingConfig();
                }
                return _AppSettingConfig;
            }
        }
        /// <summary>
        /// 根据key获取appseting的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {
            get
            {
                return _config[key];
            }
        }
        public static void Configure(IConfiguration config)
        {
            _config = config;
        }
    }
}
