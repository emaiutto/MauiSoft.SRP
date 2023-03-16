using FSUIPC;
using Newtonsoft.Json;

namespace MauiSoft.SRP.FsuipcWrapper
{

    public sealed class OffsetItem
    {

        public int Address { get; set; } // HEX VALUE OFFSET

        public string? DataType { get; set; } // DATATYPE VALUE

        public int? Length { get; set; } // Only for STRING (EX: ICAO)

        public float? Factor { get; set; } // Factor de Conversión

        public bool? Frecuency { get; set; } // Tranformacion BCD -> FLOAT

        public object? Offset { get; set; } // OBJECT AS "POINTER"

    }


    public sealed class OffsetList
    {
        public Dictionary<string, OffsetItem> Dictionary { get; }


        #region SINGLETON

        private static OffsetList? _Instance;

        public static OffsetList Instance
        {
            get
            {
                _Instance ??= new OffsetList();

                return _Instance;
            }
        }

        private OffsetList()
        {
            Dictionary = new Dictionary<string, OffsetItem>();
        }

        #endregion


        public void Load(string profile)
        {

            Dictionary.Clear();

            var files = new List<string>();


            //string DefaultPath = Path.Combine(Environment.CurrentDirectory, "profiles", "default", "offsets");

            //files.InsertRange(0, Directory.GetFiles(DefaultPath, "*.json", SearchOption.TopDirectoryOnly));


            string AircraftPath = Path.Combine(Environment.CurrentDirectory, "profiles", profile, "offsets");

            files.InsertRange(0, Directory.GetFiles(AircraftPath, "*.json", SearchOption.TopDirectoryOnly));


            foreach (var filename in files)
            {

                string data = File.ReadAllText(filename);

                Dictionary<string, OffsetItem>? _Aux = null;

                try
                {
                    _Aux = JsonConvert.DeserializeObject<Dictionary<string, OffsetItem>>(data);
                }
                catch { }


                if (_Aux == null) return;

                foreach (var value in _Aux)
                {

                    OffsetItem item = new()
                    {
                        Address = value.Value.Address,
                        DataType = value.Value.DataType,

                        Factor = value.Value.Factor,
                        Length = value.Value.Length,
                        Frecuency = value.Value.Frecuency

                    };

                    switch (item.DataType)
                    {

                        case "string":

                            int len = item.Length == null ? 0 : (int)item.Length;

                            item.Offset = new Offset<string>(item.Address, len);
                            break;

                        case "short":

                            item.Offset = new Offset<short>(item.Address);
                            break;

                        case "ushort":

                            item.Offset = new Offset<ushort>(item.Address);
                            break;


                        case "byte":

                            item.Offset = new Offset<byte>(item.Address);
                            break;


                        case "float":

                            item.Offset = new Offset<float>(item.Address);
                            break;


                        case "double":

                            item.Offset = new Offset<double>(item.Address);
                            break;

                    }

                    Dictionary.Add(value.Key, item);

                }

            }

        }


        public dynamic? GetValue(string key)
        {

            if (!Dictionary.ContainsKey(key)) return null;

            if (Dictionary[key].Offset == null) return null;

            

            float factor = Dictionary[key].Factor == null ? 1.0f : Convert.ToSingle(Dictionary[key].Factor);


            switch (Dictionary[key].DataType)
            {

                case "string": // string

                    return ((Offset<string>)Convert.ChangeType(Dictionary[key].Offset, typeof(Offset<string>), CultureInfo.InvariantCulture)).Value;


                case "short": // short --> FLOAT

                    return ((Offset<short>)Convert.ChangeType(Dictionary[key].Offset, typeof(Offset<short>), CultureInfo.InvariantCulture)).Value * factor;


                case "ushort": // ushort --> FLOAT

                    return ((Offset<ushort>)Convert.ChangeType(Dictionary[key].Offset, typeof(Offset<ushort>), CultureInfo.InvariantCulture)).Value * factor;


                case "byte": // byte --> BOOL (del codigo consumidor)

                    return ((Offset<byte>)Convert.ChangeType(Dictionary[key].Offset, typeof(Offset<byte>), CultureInfo.InvariantCulture)).Value;


                case "float": // float --> float

                    return ((Offset<float>)Convert.ChangeType(Dictionary[key].Offset, typeof(Offset<float>), CultureInfo.InvariantCulture)).Value * factor;


                case "double": // double --> float

                    return ((Offset<double>)Convert.ChangeType(Dictionary[key].Offset, typeof(Offset<double>), CultureInfo.InvariantCulture)).Value * factor;

                default:
                    break;
            }

            return null;

        }


        public int Count => Dictionary.Count;

    }

}
