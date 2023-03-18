using System.Diagnostics;
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

                    // IMPORTANTE!!! En datatype en el JSON siempre usar los tipos .NET (sin el namespace System.)
                    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types?redirectedfrom=MSDN

                    Type? tipo = null; // tipo interno del generic (DataType). El tipo de datos del OFFSET


                    try
                    {
                        if (item.DataType != null)
                            tipo = Type.GetType($"System.{item.DataType}"); // Si no hace MATCHING... sale NULL!
                    }
                    catch
                    {
                        // LOG (tipo de dato erroreo. Verificar JSON)
                        Debug.WriteLine("Utilizar tipo de datos .NET sin el namespace System.");
                    }

                    if (tipo == null)
                    {
                        Debug.WriteLine("Utilizar tipo de datos .NET sin el namespace System.");
                        continue; // LOG (tipo de dato erroreo. Verificar JSON)
                    }
                    

                    
                    // Construye el Generic en base al DataType (interno)
                    Type? tipoGenerado = typeof(Offset<>).MakeGenericType(new Type[] { tipo });

                    if (tipoGenerado == null) continue; // LOG (offset no ingresado al diccionario)

                    try
                    {
                        // El único caso particular es STRING que debe recibir Lenght como parámetro

                        if (item.DataType == "String")
                        {

                            int len = item.Length == null ? 0 : (int)item.Length;

                            if (len == 0) throw new Exception("La longitud del STRING no puede ser 0");

                            item.Offset = Activator.CreateInstance(tipoGenerado, new object[] { item.Address, len });
                        }
                        else
                        {
                            item.Offset = Activator.CreateInstance(tipoGenerado, new object[] { item.Address });
                        }

                        Dictionary.Add(value.Key, item);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Falló el ingreso del OFFSET al diccionario", ex.Message);
                    } 

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

                case "String":

                    return ((Offset<string>)Convert.ChangeType(Dictionary[key].Offset, typeof(Offset<string>), CultureInfo.InvariantCulture)).Value;


                case "Int16":

                    return ((Offset<short>)Convert.ChangeType(Dictionary[key].Offset, typeof(Offset<short>), CultureInfo.InvariantCulture)).Value * factor;


                case "UInt16":

                    return ((Offset<ushort>)Convert.ChangeType(Dictionary[key].Offset, typeof(Offset<ushort>), CultureInfo.InvariantCulture)).Value * factor;


                case "Byte": // byte --> BOOL (del codigo consumidor)

                    return ((Offset<byte>)Convert.ChangeType(Dictionary[key].Offset, typeof(Offset<byte>), CultureInfo.InvariantCulture)).Value;


                case "Single":

                    return ((Offset<float>)Convert.ChangeType(Dictionary[key].Offset, typeof(Offset<float>), CultureInfo.InvariantCulture)).Value * factor;


                case "Double":

                    return ((Offset<double>)Convert.ChangeType(Dictionary[key].Offset, typeof(Offset<double>), CultureInfo.InvariantCulture)).Value * factor;

                default:
                    break;
            }

            return null;

        }


        public int Count => Dictionary.Count;

    }

}
