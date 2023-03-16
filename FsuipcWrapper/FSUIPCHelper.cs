using FSUIPC;
using Newtonsoft.Json;

namespace MauiSoft.SRP.FsuipcWrapper
{

    public sealed class CommandItem
    {
        public int Command { get; set; }

        public int? Parameter { get; set; }

    }

    public sealed class FSUIPCHelper
    {

        private readonly Dictionary<string, CommandItem> _Dictionary;


        #region SINGLETON

        private static FSUIPCHelper? _Instance;

        public static FSUIPCHelper Instance
        {
            get
            {
                _Instance ??= new FSUIPCHelper();

                return _Instance;
            }
        }

        private FSUIPCHelper()
        {
            _Dictionary = new Dictionary<string, CommandItem>();
        }

        #endregion


        private static bool _FSUIPC_Running;
        public static bool FSUIPC_Running { get => _FSUIPC_Running; }


        static readonly Offset<int> _sendControl = new(0x3110, true);

        static readonly Offset<int> _controlParameter = new(0x3114, true);




        public int Count => _Dictionary.Count;

        public static void Open()
        {
            try
            {
                _FSUIPC_Running = true;

                FSUIPCConnection.Open();
            }
            catch
            {
                //_FSUIPC_Running = false;

                //Console.WriteLine("FSUIPC not running!");
            }
        }

        public static void Update()
        {
            try
            {
                FSUIPCConnection.Process();
            }
            catch
            {
                _FSUIPC_Running = false;

                Console.WriteLine("(Update) FSUIPC not running!");
            }
        }

        public void Execute(string key)
        {

            if (!_Dictionary.ContainsKey(key)) { return; } // LOG

            if (!FSUIPC_Running) return; // LOG

            _controlParameter.Value = 0; // Parametro Default

            if (_Dictionary[key].Parameter != null)
                _controlParameter.Value = Convert.ToInt32(_Dictionary[key].Parameter);

            _sendControl.Value = _Dictionary[key].Command;

            Update();

            _sendControl.Value = 0;
        }


        public void Load(string profile)
        {

            // Limpio el diccionario por si se implementa el cambio de profile dinamico
            // De momento, en esta version desactivado los modos DEFAULT en los profiles.
            _Dictionary.Clear();


            var files = new List<string>();


            //string DefaultPath = Path.Combine(Environment.CurrentDirectory, "profiles", "default", "commands");

            //files.InsertRange(0, Directory.GetFiles(DefaultPath, "*.json", SearchOption.TopDirectoryOnly));


            string AircraftPath = Path.Combine(Environment.CurrentDirectory, "profiles", profile, "commands");

            files.InsertRange(0, Directory.GetFiles(AircraftPath, "*.json", SearchOption.TopDirectoryOnly));


            foreach (var filename in files)
            {

                string data = File.ReadAllText(filename);

                Dictionary<string, CommandItem>? _Aux = null;

                try
                {
                    _Aux = JsonConvert.DeserializeObject<Dictionary<string, CommandItem>>(data);
                }
                catch { }

                if (_Aux == null) return;

                foreach (var value in _Aux)
                {

                    CommandItem cmd = new()
                    {
                        Command = value.Value.Command,

                        Parameter = value.Value.Parameter
                    };

                    _Dictionary.Add(value.Key, cmd);

                }

            }
        }

    }

}
