namespace WpfRoyal.WpfCommon.Tool
{
    using System;
    using System.Windows.Media;
    using WpfRoyal.WpfCommon.Core;






    public class WxFrameTimer : IDisposable
    {
        public WxFrameTimer(int delayFrame, int repeatCount = 0)
        {
            SetDelayFrame(delayFrame);
            SetRepeatCount(repeatCount);
        }

        public void Dispose()
        {
            Stop(true);
            Event = null;
        }


        public const string EtUpdate = "EtUpdate";
        public const string EtEnd = "EtEnd";

        public event WxEventHandler Event;
        private void pf_CallEvent(string type)
        {
            if (Event != null)
                Event(type);
        }



        //- 현재 진행중 여부
        private bool _running = false;
        public bool GetRunning()
        {
            return _running;
        }


        //- 딜레이 프래임
        private int _delayFrame;
        public int GetDelayFrame()
        {
            return _delayFrame;
        }
        public void SetDelayFrame(int tv)
        {
            _delayFrame = (tv < 0) ? 0 : tv;
        }


        //- 현재 프래임
        private int _nowFrame = 0;
        public int GetNowFrame()
        {
            return _nowFrame;
        }



        //- 반복 카운트
        private int _repeatCount;
        public int GetRepeatCount()
        {
            return _repeatCount;
        }
        public void SetRepeatCount(int tv)
        {
            _repeatCount = (tv < 0) ? 0 : tv;
        }


        //- 현재 카운트
        private int _currentCount = 0;
        public int GetCurrentCount()
        {
            return _currentCount;
        }


        //:: 엔터프래임
        private void pf_EnterFrame(object tsd, EventArgs tea)
        {
            if (_nowFrame >= _delayFrame)
            {
                _nowFrame = 0;
                if (_repeatCount == 0)
                {
                    _currentCount++;
                    pf_CallEvent(EtUpdate);
                }
                else
                if (_currentCount < _repeatCount)
                {
                    _currentCount++;
                    pf_CallEvent(EtUpdate);
                    if (_currentCount >= _repeatCount)
                    {
                        Stop();
                        pf_CallEvent(EtEnd);
                    }
                }
                else
                {
                    Stop();
                }
            }
            else
            {
                _nowFrame++;
            }
        }



        //:: 리셋
        public void Reset()
        {
            Stop();
            _nowFrame = 0;
            _currentCount = 0;
        }


        //:: 시작
        public void Start()
        {
            if (!_running)
            {
                if ((_repeatCount == 0) || (_currentCount < _repeatCount))
                {
                    CompositionTarget.Rendering += pf_EnterFrame;
                    _running = true;
                }
            }
        }


        //:: 정지
        public void Stop(bool bFrameReset = false)
        {
            if (_running)
            {
                CompositionTarget.Rendering -= pf_EnterFrame;
                if (bFrameReset)
                    _nowFrame = 0;
                _running = false;
            }
        }

    }
}
