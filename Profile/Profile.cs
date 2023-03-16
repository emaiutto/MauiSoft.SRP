using FSUIPC;

namespace MauiSoft.SRP.Profile
{
    public sealed class Profile
    {

        private static Profile? _Instance;

        public static Profile Instance
        {
            get
            {
                _Instance ??= new Profile();

                return _Instance;
            }
        }


        private readonly Offset<string> _AircraftProfileOffset;

        private readonly Offset<string> _AircraftNameOffset;


        private Profile()
        {
            _AircraftProfileOffset = new Offset<string>("profile", 0x9540, 64); // 64 CONSTANTE!

            _AircraftNameOffset = new Offset<string>("profile", 0x3D00, 256); // 256 Según PDF.
        }


        public string Aircraft => _AircraftProfileOffset.Value;

        public string Name => _AircraftNameOffset.Value;


        public void Update()
        {
            FSUIPCConnection.Process("profile");
        }

    }
}
