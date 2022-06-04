namespace WpfRoyal.WpfCommon.Effect
{
    using System;
    using System.Windows.Media;
    using WpfRoyal.Common.Core;






    public class WxTween : IDisposable
    {
        public WxTween(double current,
            int duration = 36, Func<double, double, double, double, double> func = null)
        {
            Running = false;

            Begin = current;
            Change = current;
            Current = current;

            Time = 0;
            Duration = duration;

            Easefunc = func ?? WxEaseFuncs.QuartInOut;
        }

        public bool Running { get; private set; }

        public double Begin { get; private set; }
        public double Change { get; private set; }
        public double Current { get; private set; }

        public int Time { get; private set; }
        public int Duration { get; private set; }

        public Func<double, double, double, double, double> Easefunc { get; private set; }


        public const string EtUpdate = "Update";
        public const string EtEnd = "End";

        public event WxEventHandler Event;
        private void pf_CallEvent(string type)
        {
            Event?.Invoke(type);
        }


        public void Dispose()
        {
            Stop();
            Easefunc = null;
            Event = null;
        }


        private void pf_EnterFrame(object tsd, EventArgs tea)
        {
            if (Time < Duration)
            {
                Time++;
                Current = Easefunc(Time, Begin, Change, Duration);
                pf_CallEvent(EtUpdate);

                if (Time >= Duration)
                {
                    pf_CallEvent(EtEnd);
                    Stop();
                }
            }

            //Debug.WriteLine("####");
        }


        public void To(double change)
        {
            if (Running) Stop();

            Time = 0;
            Begin = Current;
            Change = change - Begin;

            CompositionTarget.Rendering += pf_EnterFrame;
            Running = true;
        }


        public void Stop()
        {
            if (Running)
            {
                CompositionTarget.Rendering -= pf_EnterFrame;
                Running = false;
            }
        }


    }
}
