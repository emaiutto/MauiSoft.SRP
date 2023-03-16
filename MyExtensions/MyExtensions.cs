namespace MauiSoft.SRP.MyExtensions
{
    public static class MyExtensions
    {

        // Ordenamiento de bits
        // 7  6  5  4  3  2  1  0

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBitSet(this byte b, int pos) => (b & 1 << pos) != 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullEmptyOrSpace(this string str) =>
            string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);


        public static double MapRange(this double input, double inputLow, double inputHigh, double outputLow, double outputHigh)
            => (input - inputLow) * (outputHigh - outputLow) / (inputHigh - inputLow) + outputLow;

    }
}
