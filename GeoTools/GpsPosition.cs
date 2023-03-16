namespace MauiSoft.SRP.GeoTools
{
    public class GpsPosition
    {

        const double EARTH = 12756274d; // Diámetro de la tierra en metros

        const double SEXA2RAD = 0.01745329251994329576923690768489d;

        const double RAD2SEXA = 57.295779513082320876798154814105d;

        public GpsPosition (double latitude, double longitude)
        {
            Latitude    = latitude;
            Longitude   = longitude;

            Radian_Latitude  = SEXA2RAD * Latitude;
            Radian_Longitude = SEXA2RAD * Longitude;
        }

        public double Latitude { get; }
        public double Longitude { get; }

        public double Radian_Latitude { get; }
        public double Radian_Longitude { get; }



        public string LatitudeDMS
        {
            get
            {
                char cardinal = Latitude > 0 ? 'N' : 'S';

                return $"{DecimalToDMS(Latitude)} {cardinal}";
            }

        }

        public string LongitudeDMS
        {
            get
            {
                char cardinal = Latitude > 0 ? 'E' : 'W';

                return $"{DecimalToDMS(Longitude)} {cardinal}";
            }
        }


        private string DecimalToDMS(double decimalCoord)
        {

            decimalCoord = Math.Abs(decimalCoord);

            int degrees = (int)decimalCoord;

            double minutesFromRemainder = (decimalCoord - degrees) * 60;

            int minutes = (int)minutesFromRemainder;

            double secondsFromRemainder = (minutesFromRemainder - minutes) * 60;

            int seconds = (int)secondsFromRemainder;

            return $"{degrees}° {minutes}' {seconds}''";

        }


        public double Distance(GpsPosition to)
        {

            double dlon = to.Radian_Longitude - Radian_Longitude;

            double dlat = to.Radian_Latitude - Radian_Latitude;

            double sinlat = Math.Sin(dlat / 2d);

            double sinlon = Math.Sin(dlon / 2d);

            double a = (sinlat * sinlat) + Math.Cos(Radian_Latitude) * Math.Cos(to.Radian_Latitude) * (sinlon * sinlon);

            return EARTH * Math.Sin(Math.Min(1, Math.Sqrt(a)));

        }

        public double Bearing(GpsPosition to)
        {

            double dlon = to.Radian_Longitude - Radian_Longitude;

            var y = Math.Sin(dlon) * Math.Cos(to.Radian_Latitude);

            var x = Math.Cos(Radian_Latitude) * Math.Sin(to.Radian_Latitude) -
                    Math.Sin(Radian_Latitude) * Math.Cos(to.Radian_Latitude) * Math.Cos(dlon);

            return Normalizar360(Rad2Gra(Math.Atan2(y, x)));

        }


        #region Normalizar 360

        /// <summary>
        /// Normalizar
        /// </summary>
        /// <param name="angulo"></param>
        /// <returns></returns>
        public static double Normalizar360(double angulo)
        {
            angulo %= 360;

            if (angulo < 0) angulo += 360;

            return angulo;
        }

        #endregion Normalizar 360


        #region Conversion Radianes <--> Sexagesimal

        public static double Rad2Gra(double rad) => rad * RAD2SEXA;

        public static double Gra2Rad(double gra) => gra * SEXA2RAD;

        #endregion Conversion Radianes <--> Sexagesimal

    }
}
