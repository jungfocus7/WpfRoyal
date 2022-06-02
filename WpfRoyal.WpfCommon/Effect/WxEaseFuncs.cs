namespace WpfRoyal.WpfCommon.Effect
{
    public static class WxEaseFuncs
    {
        public static double InOut(double t, double b, double c, double d)
        {
            if ((t /= d / 2) < 1) return c / 2 * t * t * t * t * t + b;
            return c / 2 * ((t -= 2) * t * t * t * t + 2) + b;
        }
    }
}
