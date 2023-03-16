using MauiSoft.SRP.MyExtensions;
using Newtonsoft.Json;

namespace MauiSoft.SRP.Gauges
{

    public interface IPanel
    {
        void Update(DiplayItem display);
    }

    public sealed class DiplayItem
    {
        public string? Label { get; set; }

        public string[]? Data { get; set; }

    }


    public sealed class Display
    {
        public Dictionary<int, DiplayItem>? Dictionary { get; set; }


        #region SINGLETON

        private static Display? _Instance;

        public static Display Instance
        {
            get
            {
                _Instance ??= new Display();

                return _Instance;
            }
        }

        private Display()
        {

            Dictionary = new Dictionary<int, DiplayItem>();

        }

        #endregion


        public void Load(string profile)
        {
            try
            {
                string filename = Path.Combine(Environment.CurrentDirectory, "profiles", profile, "displays.json");

                string data = File.ReadAllText(filename);

                if (data.IsNullEmptyOrSpace()) throw new Exception("Display Config Empty");

                Dictionary = JsonConvert.DeserializeObject<Dictionary<int, DiplayItem>>(data);

            }
            catch (Exception ex)
            {
                Dictionary = null;

                throw new Exception("Display Config Not Load!", ex);
            }
        }

    }

}
