namespace WpfRoyal.WpfCommon.Effect
{
    using System;





    /// <summary>
    /// Tween ease functions
    /// [참고: ] https://gist.github.com/mrhelmut/3b70813cacc6c2e1e9f853b74e124dae
    /// </summary>
    public static class WxEaseFuncs
    {
        public static double BackIn(double t, double b, double c, double d)
        {
            double s = 1.70158f;
            return c * (t /= d) * t * ((s + 1) * t - s) + b;
        }

        public static double BackIn(double t, double b, double c, double d, double s)
        {
            return c * (t /= d) * t * ((s + 1) * t - s) + b;
        }

        public static double BackOut(double t, double b, double c, double d)
        {
            double s = 1.70158f;
            return c * ((t = t / d - 1) * t * ((s + 1) * t + s) + 1) + b;
        }

        public static double BackOut(double t, double b, double c, double d, double s)
        {
            return c * ((t = t / d - 1) * t * ((s + 1) * t + s) + 1) + b;
        }

        public static double BackInOut(double t, double b, double c, double d)
        {
            double s = 1.70158f;
            if ((t /= d / 2) < 1) return c / 2 * (t * t * (((s *= (1.525f)) + 1) * t - s)) + b;
            return c / 2 * ((t -= 2) * t * (((s *= (1.525f)) + 1) * t + s) + 2) + b;
        }

        public static double BackInOut(double t, double b, double c, double d, double s)
        {
            if ((t /= d / 2) < 1) return c / 2 * (t * t * (((s *= (1.525f)) + 1) * t - s)) + b;
            return c / 2 * ((t -= 2) * t * (((s *= (1.525f)) + 1) * t + s) + 2) + b;
        }



        public static double BounceIn(double t, double b, double c, double d)
        {
            return c - BounceOut(d - t, 0, c, d) + b;
        }

        public static double BounceOut(double t, double b, double c, double d)
        {
            if ((t /= d) < (1 / 2.75f))
                return c * (7.5625f * t * t) + b;
            else if (t < (2 / 2.75f))
                return c * (7.5625f * (t -= (1.5f / 2.75f)) * t + .75f) + b;
            else if (t < (2.5 / 2.75))
                return c * (7.5625f * (t -= (2.25f / 2.75f)) * t + .9375f) + b;
            else
                return c * (7.5625f * (t -= (2.625f / 2.75f)) * t + .984375f) + b;
        }

        public static double BounceInOut(double t, double b, double c, double d)
        {
            if (t < d / 2) return BounceIn(t * 2, 0, c, d) * .5f + b;
            else return BounceOut(t * 2 - d, 0, c, d) * .5f + c * .5f + b;
        }



        public static double CircIn(double t, double b, double c, double d)
        {
            return -c * (Math.Sqrt(1 - (t /= d) * t) - 1) + b;
        }

        public static double CircOut(double t, double b, double c, double d)
        {
            return c * Math.Sqrt(1 - (t = t / d - 1) * t) + b;
        }

        public static double CircInOut(double t, double b, double c, double d)
        {
            if ((t /= d / 2) < 1) return -c / 2 * (Math.Sqrt(1 - t * t) - 1) + b;
            return c / 2 * (Math.Sqrt(1 - (t -= 2) * t) + 1) + b;
        }



        public static double CubicIn(double t, double b, double c, double d)
        {
            return c * (t /= d) * t * t + b;
        }

        public static double CubicOut(double t, double b, double c, double d)
        {
            return c * ((t = t / d - 1) * t * t + 1) + b;
        }

        public static double CubicInOut(double t, double b, double c, double d)
        {
            if ((t /= d / 2) < 1) return c / 2 * t * t * t + b;
            return c / 2 * ((t -= 2) * t * t + 2) + b;
        }



        public static double ElasticIn(double t, double b, double c, double d)
        {
            if (t == 0) return b; if ((t /= d) == 1) return b + c;
            double p = d * .3f;
            double a = c;
            double s = p / 4;
            return -(a * Math.Pow(2, 10 * (t -= 1)) * Math.Sin((t * d - s) * (2 * Math.PI) / p)) + b;
        }

        public static double ElasticIn(double t, double b, double c, double d, double a, double p)
        {
            double s;
            if (t == 0) return b; if ((t /= d) == 1) return b + c;
            if (a < Math.Abs(c)) { a = c; s = p / 4; }
            else s = p / (2 * Math.PI) * Math.Asin(c / a);
            return -(a * Math.Pow(2, 10 * (t -= 1)) * Math.Sin((t * d - s) * (2 * Math.PI) / p)) + b;
        }

        public static double ElasticOut(double t, double b, double c, double d)
        {
            if (t == 0) return b; if ((t /= d) == 1) return b + c;
            double p = d * .3f;
            double a = c;
            double s = p / 4;
            return a * Math.Pow(2, -10 * t) * Math.Sin((t * d - s) * (2 * Math.PI) / p) + c + b;
        }

        public static double ElasticOut(double t, double b, double c, double d, double a, double p)
        {
            double s;
            if (t == 0) return b; if ((t /= d) == 1) return b + c;
            if (a < Math.Abs(c)) { a = c; s = p / 4; }
            else s = p / (2 * Math.PI) * Math.Asin(c / a);
            return a * Math.Pow(2, -10 * t) * Math.Sin((t * d - s) * (2 * Math.PI) / p) + c + b;
        }

        public static double ElasticInOut(double t, double b, double c, double d)
        {
            if (t == 0) return b; if ((t /= d / 2) == 2) return b + c;
            double p = d * (.3f * 1.5f);
            double a = c;
            double s = p / 4;
            if (t < 1) return -.5f * (a * Math.Pow(2, 10 * (t -= 1)) * Math.Sin((t * d - s) * (2 * Math.PI) / p)) + b;
            return a * Math.Pow(2, -10 * (t -= 1)) * Math.Sin((t * d - s) * (2 * Math.PI) / p) * .5f + c + b;
        }

        public static double ElasticInOut(double t, double b, double c, double d, double a, double p)
        {
            double s;
            if (t == 0) return b; if ((t /= d / 2) == 2) return b + c;
            if (a < Math.Abs(c)) { a = c; s = p / 4; }
            else { s = p / (2 * Math.PI) * Math.Asin(c / a); }
            if (t < 1) return -.5f * (a * Math.Pow(2, 10 * (t -= 1)) * Math.Sin((t * d - s) * (2 * Math.PI) / p)) + b;
            return a * Math.Pow(2, -10 * (t -= 1)) * Math.Sin((t * d - s) * (2 * Math.PI) / p) * .5f + c + b;
        }



        public static double ExpoIn(double t, double b, double c, double d)
        {
            return (t == 0) ? b : c * Math.Pow(2, 10 * (t / d - 1)) + b;
        }

        public static double ExpoOut(double t, double b, double c, double d)
        {
            return (t == d) ? b + c : c * (-Math.Pow(2, -10 * t / d) + 1) + b;
        }

        public static double ExpoInOut(double t, double b, double c, double d)
        {
            if (t == 0) return b;
            if (t == d) return b + c;
            if ((t /= d / 2) < 1) return c / 2 * Math.Pow(2, 10 * (t - 1)) + b;
            return c / 2 * (-Math.Pow(2, -10 * --t) + 2) + b;
        }



        public static double LinearNone(double t, double b, double c, double d)
        {
            return c * t / d + b;
        }

        public static double LinearIn(double t, double b, double c, double d)
        {
            return c * t / d + b;
        }

        public static double LinearOut(double t, double b, double c, double d)
        {
            return c * t / d + b;
        }

        public static double LinearInOut(double t, double b, double c, double d)
        {
            return c * t / d + b;
        }



        public static double QuadIn(double t, double b, double c, double d)
        {
            return c * (t /= d) * t + b;
        }

        public static double QuadOut(double t, double b, double c, double d)
        {
            return -c * (t /= d) * (t - 2) + b;
        }

        public static double QuadInOut(double t, double b, double c, double d)
        {
            if ((t /= d / 2) < 1) return c / 2 * t * t + b;
            return -c / 2 * ((--t) * (t - 2) - 1) + b;
        }



        public static double QuartIn(double t, double b, double c, double d)
        {
            return c * (t /= d) * t * t * t + b;
        }

        public static double QuartOut(double t, double b, double c, double d)
        {
            return -c * ((t = t / d - 1) * t * t * t - 1) + b;
        }

        public static double QuartInOut(double t, double b, double c, double d)
        {
            if ((t /= d / 2) < 1) return c / 2 * t * t * t * t + b;
            return -c / 2 * ((t -= 2) * t * t * t - 2) + b;
        }



        public static double QuintIn(double t, double b, double c, double d)
        {
            return c * (t /= d) * t * t * t * t + b;
        }

        public static double QuintOut(double t, double b, double c, double d)
        {
            return c * ((t = t / d - 1) * t * t * t * t + 1) + b;
        }

        public static double QuintInOut(double t, double b, double c, double d)
        {
            if ((t /= d / 2) < 1) return c / 2 * t * t * t * t * t + b;
            return c / 2 * ((t -= 2) * t * t * t * t + 2) + b;
        }



        public static double SineIn(double t, double b, double c, double d)
        {
            return -c * Math.Cos(t / d * (Math.PI / 2)) + c + b;
        }

        public static double SineOut(double t, double b, double c, double d)
        {
            return c * Math.Sin(t / d * (Math.PI / 2)) + b;
        }

        public static double SineInOut(double t, double b, double c, double d)
        {
            return -c / 2 * (Math.Cos(Math.PI * t / d) - 1) + b;
        }








        //public static double InOut(double t, double b, double c, double d)
        //{
        //    if ((t /= d / 2) < 1) return c / 2 * t * t * t * t * t + b;
        //    return c / 2 * ((t -= 2) * t * t * t * t + 2) + b;
        //}


    }
}
