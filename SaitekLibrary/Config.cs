using MauiSoft.SRP.MyExtensions;
using Newtonsoft.Json;

namespace MauiSoft.SRP.SaitekLibrary
{

    public sealed class ConfigItem
    {
        public string[]? BRR { get; set; } // Big Rotary Right
        public string[]? BRL { get; set; } // Big Rotary Left

        public string[]? SRR { get; set; } // Small Rotary Right
        public string[]? SRL { get; set; } // Small Rotary Left

        public string[]? BTN { get; set; } // Button

        public string[]? DSL { get; set; } // Display Left
        public string[]? DSR { get; set; } // Display Right
    }


    public sealed class Config
    {

        const string CONFIG_FILE = "config.json";

        private Dictionary<int, ConfigItem>? Dictionary { get; set; }


        #region SINGLETON

        private static Config? _Instance;

        public static Config Instance
        {
            get
            {
                _Instance ??= new Config();

                return _Instance;
            }
        }

        private Config()
        {
            Dictionary = new Dictionary<int, ConfigItem>();
        }

        #endregion


        public void Load(string profile)
        {
            try
            {
                string filename = Path.Combine(Environment.CurrentDirectory, "profiles", profile, CONFIG_FILE);

                string data = File.ReadAllText(filename);

                if (data.IsNullEmptyOrSpace()) throw new Exception("Saitek Config Empty");

                Dictionary = JsonConvert.DeserializeObject<Dictionary<int, ConfigItem>>(data);

            }
            catch (Exception ex)
            {
                Dictionary = null;

                throw new Exception("Saitek Config Not Load!", ex);
            }
        }

        public ConfigItem? Get(int index)
        {

            try
            {
                return Dictionary?[index];
            }
            catch
            {
                return null;
            }
        }


    }
}
